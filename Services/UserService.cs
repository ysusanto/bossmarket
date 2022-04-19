using AutoMapper;
using BCryptNet = BCrypt.Net.BCrypt;
using System.Linq;
using bossmarket.Entities;
using bossmarket.Models.Users;
using bossmarket.Helpers;
using bossmarket.Authorization;
using Microsoft.Extensions.Options;
namespace bossmarket.Services
{
    public interface IUserService
    {
        IEnumerable<Users> GetAll();
        Users GetById(int id);
        void Create(CreateUser model);
        // void Update(int id, UpdateRequest model);
        void Delete(int id);
        AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress);
        AuthenticateResponse RefreshToken(string token, string ipAddress);
        void RevokeToken(string token, string ipAddress);
    }
    public class UserService : IUserService
    {
        private DataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private DateTime Today = DateTime.Now;
        private IJwtUtils _jwtUtils;

        public UserService(DataContext context, IMapper mapper, IJwtUtils jwtUtils, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }
        public IEnumerable<Users> GetAll()
        {
            return _context.Users.Where(c => !c.DeletedAt.HasValue);
        }
        private Users getUser(int id)
        {
            var user = _context.Users.Where(c => !c.DeletedAt.HasValue && c.Id == id).FirstOrDefault();
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
        public Users GetById(int id)
        {
            return getUser(id);
        }
        public void Delete(int id)
        {
            var user = getUser(id);
            user.DeletedAt = Today;
            _context.Users.Update(user);
            _context.SaveChanges();
        }
        public void Create(CreateUser model)
        {
            // validate
            if (_context.Users.Any(x => x.Email == model.Email))
                throw new AppException("User with the email '" + model.Email + "' already exists");

            // map model to new user object
            var user = _mapper.Map<Users>(model);

            // hash password
            user.PasswordHash = BCryptNet.HashPassword(model.Password);
            user.CreatedAt = Today;

            // save user
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model, string ipAddress)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);

            // validate
            if (user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
                throw new AppException("Username or password is incorrect");

            // authentication successful so generate jwt and refresh tokens
            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            var refreshToken = _jwtUtils.GenerateRefreshToken(ipAddress);
            refreshToken.ReasonRevoked = refreshToken.ReasonRevoked == null ? "" : refreshToken.ReasonRevoked;
            refreshToken.ReplacedByToken = refreshToken.ReplacedByToken == null ? "" : refreshToken.ReasonRevoked;
            refreshToken.RevokedByIp = refreshToken.RevokedByIp == null ? "" : refreshToken.ReasonRevoked;
            user.RefreshTokens.Add(refreshToken);

            // remove old refresh tokens from user
            removeOldRefreshTokens(user);

            // save changes to db
            _context.Update(user);
            _context.SaveChanges();

            return new AuthenticateResponse(user, jwtToken, refreshToken.Token);
        }

        public AuthenticateResponse RefreshToken(string token, string ipAddress)
        {
            var user = getUserByRefreshToken(token);
            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            if (refreshToken.IsRevoked)
            {
                // revoke all descendant tokens in case this token has been compromised
                revokeDescendantRefreshTokens(refreshToken, user, ipAddress, $"Attempted reuse of revoked ancestor token: {token}");
                _context.Update(user);
                _context.SaveChanges();
            }

            if (!refreshToken.IsActive)
                throw new AppException("Invalid token");

            // replace old refresh token with a new one (rotate token)
            var newRefreshToken = rotateRefreshToken(refreshToken, ipAddress);
            user.RefreshTokens.Add(newRefreshToken);

            // remove old refresh tokens from user
            removeOldRefreshTokens(user);

            // save changes to db
            _context.Update(user);
            _context.SaveChanges();

            // generate new jwt
            var jwtToken = _jwtUtils.GenerateJwtToken(user);

            return new AuthenticateResponse(user, jwtToken, newRefreshToken.Token);
        }

        public void RevokeToken(string token, string ipAddress)
        {
            var user = getUserByRefreshToken(token);
            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);

            if (!refreshToken.IsActive)
                throw new AppException("Invalid token");

            // revoke token and save
            revokeRefreshToken(refreshToken, ipAddress, "Revoked without replacement");
            _context.Update(user);
            _context.SaveChanges();
        }
        private Users getUserByRefreshToken(string token)
        {
            var user = _context.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));

            if (user == null)
                throw new AppException("Invalid token");

            return user;
        }

        private RefreshToken rotateRefreshToken(RefreshToken refreshToken, string ipAddress)
        {
            var newRefreshToken = _jwtUtils.GenerateRefreshToken(ipAddress);
            revokeRefreshToken(refreshToken, ipAddress, "Replaced by new token", newRefreshToken.Token);
            return newRefreshToken;
        }

        private void removeOldRefreshTokens(Users user)
        {
            // remove old inactive refresh tokens from user based on TTL in app settings
            user.RefreshTokens.RemoveAll(x =>
                !x.IsActive &&
                x.Created.AddDays(_appSettings.RefreshTokenTTL) <= DateTime.UtcNow);
        }

        private void revokeDescendantRefreshTokens(RefreshToken refreshToken, Users user, string ipAddress, string reason)
        {
            // recursively traverse the refresh token chain and ensure all descendants are revoked
            if (!string.IsNullOrEmpty(refreshToken.ReplacedByToken))
            {
                var childToken = user.RefreshTokens.SingleOrDefault(x => x.Token == refreshToken.ReplacedByToken);
                if (childToken.IsActive)
                    revokeRefreshToken(childToken, ipAddress, reason);
                else
                    revokeDescendantRefreshTokens(childToken, user, ipAddress, reason);
            }
        }

        private void revokeRefreshToken(RefreshToken token, string ipAddress, string reason = null, string replacedByToken = null)
        {
            token.Revoked = DateTime.UtcNow;
            token.RevokedByIp = ipAddress;
            token.ReasonRevoked = reason;
            token.ReplacedByToken = replacedByToken;
        }

    }
}

