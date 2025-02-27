using AutoMapper;
using first.EF.classes;
using First.Core.DTO;
using First.Core.Interfaces;
using First.Core.Models;

namespace first.EF.Services
{
    public class ProductServices: IProductService
    {
        private readonly IBaseRepo<product> _Product;
        private readonly IMapper _map;

        private readonly AppDbContext _Context;
        public ProductServices(AppDbContext Context, IMapper map) { 
            _Context = Context;
            _Product = new BaseRepo<product>(_Context);
            _map = map;
        }

        public product AddProduct(ProductDto NewProduct,int id)
        {

            var ProductAdded = _map.Map<product>(NewProduct);
            ProductAdded.CreatedBy = id;
            return _Product.Add(ProductAdded);
        }

        public IEnumerable<product> GetAllProduct()
        {
            return _Product.GetAll();
        }

        public product GetProductById(int id)
        {
           var ProductById= _Product.GetById(id);
            if (ProductById == null)
                return null;
            return ProductById;
        }
        public product Editproduct(EditProductDto EditProduct)
        {
            product oldProduct = _Product.GetById(EditProduct.Id);
            if (oldProduct == null)
                return null;
            _map.Map(EditProduct,oldProduct);
             _Product.Edit(oldProduct);
            return oldProduct;
        }

        public product Deleteproduct(int id)
        {
            product DeletedPro = _Product.GetById(id);
            if (DeletedPro == null)
                return null;
            return _Product.Delete(DeletedPro);
        }
    }
}
