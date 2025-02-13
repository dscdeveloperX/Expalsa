using DscApi.Interfaces;
using DscApi.Models.Entity;
using DscApi.Models.Request;
using DscApi.Repositories;
using Microsoft.Data.SqlClient;

namespace DscApi.Services
{
    public class CatalogService : ICatalogService
    {

        private readonly ICatalogRepository _catalogRepository;


        public CatalogService(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }



        public async Task<List<Catalog>> GetCatalogByGroup(string grupo)
        {
            try
            {
                return await _catalogRepository.GetCatalogByGroup(grupo);
            }
            catch (SqlException ex)
            {
                throw new Exception("Servicio: ", ex);
            }
        }

    }
}
