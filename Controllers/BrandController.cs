using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using bossmarket.Models.Brand;
using bossmarket.Services;
using bossmarket.Authorization;
namespace bossmarket.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BrandController : ControllerBase
    {
        private IBrandService _brandService;
        private IMapper _mapper;
        public BrandController(IBrandService brandService, IMapper mapper)
        {
            _brandService = brandService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var brands = _brandService.GetAll();
            return Ok(brands);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var brand = _brandService.GetById(id);
            return Ok(brand);
        }

        [HttpPost]
        public IActionResult Create(CreateBrand model)
        {
            _brandService.Create(model);
            return Ok(new { message = "Brand created" });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _brandService.Delete(id);
            return Ok(new { message = "Brand deleted" });
        }
        [HttpPut]
        public IActionResult Update(UpdateBrand model)
        {
            _brandService.Update(model);
            return Ok(new { message = "Brand Updated" });
        }
    }
}