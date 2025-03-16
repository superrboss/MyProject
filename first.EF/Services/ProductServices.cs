using AutoMapper;
using first.EF.classes;
using First.Core.DTO;
using First.Core.Interfaces;
using First.Core.IUnitOfWork;
using First.Core.Models;

namespace first.EF.Services
{
    public class ProductServices: IProductService
    {
        //private readonly IBaseRepo<product> _Product;

        private readonly IUnitOfWork _UniteOfwork;
        private readonly IMapper _map;

        private readonly AppDbContext _Context;
        public ProductServices(AppDbContext Context, IMapper map, IUnitOfWork UniteOfwork) { 
            _Context = Context;
            //_Product = new BaseRepo<product>(_Context);
            _UniteOfwork = UniteOfwork;
            _map = map;
        }

        public product AddProduct(ProductDto NewProduct,int id)
        {

            var ProductAdded = _map.Map<product>(NewProduct);
            ProductAdded.CreatedBy = id;
            return _UniteOfwork.products.Add(ProductAdded);
        }

        public IEnumerable<product> GetAllProduct()
        {
            return _UniteOfwork.products.GetAll();
        }

        public product GetProductById(int id)
        {
           var ProductById= _UniteOfwork.products.GetById(id);
            if (ProductById == null)
                return null;
            return ProductById;
        }
        public product Editproduct(EditProductDto EditProduct)
        {
            product oldProduct = _UniteOfwork.products.GetById(EditProduct.Id);
            if (oldProduct == null)
                return null;
            _map.Map(EditProduct,oldProduct);
             _UniteOfwork.products.Edit(oldProduct);
            return oldProduct;
        }

        public product Deleteproduct(int id)
        {
            product DeletedPro = _UniteOfwork.products.GetById(id);
            if (DeletedPro == null)
                return null;
            return _UniteOfwork.products.Delete(DeletedPro);
        }
    }
}
