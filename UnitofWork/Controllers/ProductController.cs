using Microsoft.AspNetCore.Mvc;
using UnitofWork.Models;
using UnitofWork.UnitOfWork;

namespace UnitofWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _unitOfWork.Products.GetAll();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            _unitOfWork.Products.Add(product);
            _unitOfWork.Commit();
            return Ok(product);
        }
    }
}
