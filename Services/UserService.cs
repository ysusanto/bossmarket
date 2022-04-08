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
            _context.Users.Remove(user);
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

    }
}

