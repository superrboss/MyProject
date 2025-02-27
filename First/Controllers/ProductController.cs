using first.EF.Services;
using First.Core.DTO;
using First.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace First.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _Product;
        public ProductController(IProductService product)
        {
            _Product = product;
        }

        [HttpPost]
        public IActionResult AddProduct(ProductDto NewPro)
        {

            var authorizationHeader = Request.Headers["Authorization"].ToString();
            var token = authorizationHeader.Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var UserId = jwtToken.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;

            return Ok(_Product.AddProduct(NewPro, int.Parse(UserId)));
        }

        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(_Product.GetAllProduct());
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var ExitProduct = _Product.GetProductById(id);
            if (ExitProduct == null)
                return NotFound("Not found Product have this id ");
            return Ok(ExitProduct);
        }

        [HttpPut("{id}")]
        public IActionResult EditProduct(EditProductDto NewProducts)
        {
            var Editproduct = _Product.Editproduct(NewProducts);
            if (Editproduct == null)
                return NotFound("Not found Product have this id ");

            return Ok(Editproduct);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var ExitPro = _Product.Deleteproduct(id);
            if (ExitPro == null)
                return NotFound("Not have this product id");
            return Ok(ExitPro);
        }
    }
}
