using DscApi.Interfaces;
using DscApi.Models.Entity;
using Microsoft.Data.SqlClient;

namespace DscApi.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        public string connectionString { get; }



        public CatalogRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("dsccnnstr");
        }


        public async Task<List<Catalog>> GetCatalogByGroup(string grupo)
        {

            List<Catalog> catalogs = new List<Catalog>();

            try
            {



                using (SqlConnection cnn = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand("DscSprCatalogByGroup", cnn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Grupo", System.Data.SqlDbType.NVarChar) { Value = grupo, Size = 100, Direction = System.Data.ParameterDirection.Input });

                        await cnn.OpenAsync();
                        using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                        {
                            while (await dr.ReadAsync())
                            {
                                catalogs.Add(
                                    new Catalog()
                                    {
                                        Id = Convert.ToInt32(dr["Id"]),
                                        Valor = dr["Valor"].ToString()
                                    }
                                    );
                            }
                        }
                    }

                }

                return catalogs;


            }
            catch (SqlException ex)
            {
                throw new Exception("repository: ", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("error: ", ex);
            }


        }

    }
}