using First.Core.DTO;
using First.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace first.EF.Services
{
    public interface IProductService
    {
        IEnumerable<product> GetAllProduct();
        product GetProductById(int id);
        product AddProduct(ProductDto NewProduct, int id);
        product Editproduct(EditProductDto EditProduct);
        product Deleteproduct(int id);


    }
}
