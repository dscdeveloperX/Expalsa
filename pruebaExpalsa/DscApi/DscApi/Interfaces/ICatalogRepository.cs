using DscApi.Models.Entity;

namespace DscApi.Interfaces
{
    public interface ICatalogRepository
    {
        public Task<List<Catalog>> GetCatalogByGroup(string grupo);
    }
}
