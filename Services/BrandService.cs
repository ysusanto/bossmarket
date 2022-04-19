using bossmarket.Entities;
using bossmarket.Models.Brand;
using bossmarket.Helpers;
using Microsoft.Extensions.Options;
using AutoMapper;
namespace bossmarket.Services
{
    public interface IBrandService
    {
        IEnumerable<Brands> GetAll();
        Brands GetById(int id);
        void Create(CreateBrand model);
        // void Update(int id, UpdateRequest model);
        void Delete(int id);
        void Update(UpdateBrand model);
    }
    public class BrandService : IBrandService
    {
        private DataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        private DateTime Today = DateTime.Now;

        public BrandService(DataContext context, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
        public IEnumerable<Brands> GetAll()
        {
            return _context.Brands.Where(c => !c.DeletedAt.HasValue);
        }
        private Brands getBrand(int id)
        {
            var brand = _context.Brands.Where(c => !c.DeletedAt.HasValue && c.Id == id).FirstOrDefault();
            if (brand == null) throw new KeyNotFoundException("Brand not found");
            return brand;
        }
        public Brands GetById(int id)
        {
            return getBrand(id);
        }
        public void Delete(int id)
        {
            var brand = getBrand(id);
            brand.DeletedAt = Today;
            _context.Brands.Update(brand);
            _context.SaveChanges();
        }
        public void Create(CreateBrand model)
        {
            if (_context.Brands.Any(x => x.Name == model.Name && x.DeletedAt.HasValue))
                throw new AppException("Brand '" + model.Name + "' already exists");

            var brand = _mapper.Map<Brands>(model);
            brand.CreatedAt = Today;
            _context.Brands.Add(brand);
            _context.SaveChanges();
        }
        public void Update(UpdateBrand model)
        {
            if (_context.Brands.Any(x => x.Name == model.Name && x.DeletedAt.HasValue))
                throw new AppException("Brand '" + model.Name + "' already exists");

            var brand = _mapper.Map<Brands>(model);
            brand.ModifiedAt = Today;
            _context.Brands.Add(brand);
            _context.SaveChanges();
        }
    }
}