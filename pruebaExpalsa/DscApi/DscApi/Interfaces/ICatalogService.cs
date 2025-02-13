using DscApi.Models.Entity;

namespace DscApi.Interfaces
{
    public interface ICatalogService
    {
        public Task<List<Catalog>> GetCatalogByGroup(string grupo);
    }
}
