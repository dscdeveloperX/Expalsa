using DscApi.Interfaces;
using DscApi.Models.Entity;
using DscApi.Models.Request;
using Microsoft.Data.SqlClient;

namespace DscApi.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;


        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public async Task<bool> CreateProduct(ProductCreateOrEditRequest request)
        {
            try
            {
                return await _productRepository.CreateProduct(request);
            }
            catch (SqlException ex)
            {
                throw new Exception("Servicio: ", ex);
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {
                return await _productRepository.DeleteProduct(id);
            }
            catch (SqlException ex)
            {
                throw new Exception("Servicio: ", ex);
            }
        }

        public async Task<List<Product>> GetProductAll()
        {
            try
            {
                return await _productRepository.GetProductAll();
            }
            catch (SqlException ex)
            {
                throw new Exception("Servicio: ", ex);
            }
        }

        
        public async Task<Product> GetProductById(int id)
        {
            try
            {
                return await _productRepository.GetProductById(id);
            }
            catch (SqlException ex)
            {
                throw new Exception("Servicio: ", ex);
            }
        }

        public async Task<bool> UpdateProduct(int id, ProductCreateOrEditRequest request)
        {
            try
            {
                return await _productRepository.UpdateProduct(id, request);
            }
            catch (SqlException ex)
            {
                throw new Exception("Servicio: ", ex);
            }
        }
    }
}
