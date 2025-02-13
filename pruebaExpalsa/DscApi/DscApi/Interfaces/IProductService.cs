using DscApi.Models.Entity;
using DscApi.Models.Request;

namespace DscApi.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> GetProductAll();
        public Task<Product> GetProductById(int id);
        public Task<bool> CreateProduct(ProductCreateOrEditRequest request);
        public Task<bool> UpdateProduct(int id, ProductCreateOrEditRequest request);
        public Task<bool> DeleteProduct(int id);
    }
}
