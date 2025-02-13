using DscApi.Interfaces;
using DscApi.Models.Entity;
using DscApi.Models.Request;
using Microsoft.Data.SqlClient;

namespace DscApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public string connectionString { get; }



        public ProductRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("dsccnnstr");
        }


        public async Task<bool> CreateProduct(ProductCreateOrEditRequest request)
        {


            try
            {

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand("DscSprProductsCreate", cnn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Foto", System.Data.SqlDbType.NVarChar) { Value = request.Foto, Size = -1, Direction = System.Data.ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar) { Value = request.Nombre, Size = 200, Direction = System.Data.ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter("@Talla", System.Data.SqlDbType.NVarChar) { Value = request.Talla, Size = 50, Direction = System.Data.ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter("@EstatusCabezaId", System.Data.SqlDbType.Int) { Value = request.EstatusCabezaId, Direction = System.Data.ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter("@CongelamientoId", System.Data.SqlDbType.Int) { Value = request.CongelamientoId, Direction = System.Data.ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter("@MarcaId", System.Data.SqlDbType.Int) { Value = request.MarcaId, Direction = System.Data.ParameterDirection.Input });


                        await cnn.OpenAsync();
                        int files = await cmd.ExecuteNonQueryAsync();
                        return (files > 0);
                    }

                }



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

        public async Task<bool> DeleteProduct(int id)
        {
            try
            {

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand("DscSprProductsDelete", cnn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", System.Data.SqlDbType.Int) { Value = id, Direction = System.Data.ParameterDirection.Input });


                        await cnn.OpenAsync();
                        int files = await cmd.ExecuteNonQueryAsync();
                        return (files > 0);
                    }

                }



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

        public async Task<List<Product>> GetProductAll()
        {
            List<Product> products = new List<Product>();

            try
            {



                using (SqlConnection cnn = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand("DscSprProductGetAll", cnn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        await cnn.OpenAsync();
                        using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                        {
                            while (await dr.ReadAsync())
                            {
                              

                               products.Add(
                                    new Product()
                                    {
                                       Id = Convert.ToInt32(dr["Id"]),
                                       Foto = dr["Foto"].ToString(),
                                       Nombre = dr["Nombre"].ToString(),
                                       Talla = dr["Talla"].ToString(),
                                       EstatusCabezaId = Convert.ToInt32(dr["EstatusCabezaId"]),
                                        EstatusCabezaName = dr["EstatusCabezaName"].ToString(),
                                       CongelamientoId = Convert.ToInt32(dr["CongelamientoId"]),
                                       CongelamientoName = dr["CongelamientoName"].ToString(),
                                       MarcaId = Convert.ToInt32(dr["MarcaId"]),
                                        MarcaName = dr["MarcaName"].ToString()
                                    }
                                    );
                            }
                        }
                    }

                }

                return products;


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


        public async Task<Product> GetProductById(int id)
        {
            Product product = new Product();

            try
            {

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand("DscSprProductGetById", cnn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", System.Data.SqlDbType.Int) { Value = id, Direction = System.Data.ParameterDirection.Input });

                        await cnn.OpenAsync();
                        using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
                        {
                            while (await dr.ReadAsync())
                            {
                                product.Id = Convert.ToInt32(dr["Id"]);
                                product.Foto = dr["Foto"].ToString();
                                product.Nombre= dr["Nombre"].ToString();
                                product.Talla = dr["Talla"].ToString();
                                product.EstatusCabezaId = Convert.ToInt32(dr["EstatusCabezaId"]);
                                product.CongelamientoId = Convert.ToInt32(dr["CongelamientoId"]);
                                product.MarcaId = Convert.ToInt32(dr["MarcaId"]);

                            }
                        }
                    }

                }

                return product;


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


        public async Task<bool> UpdateProduct(int id, ProductCreateOrEditRequest request)
        {


            try
            {

                using (SqlConnection cnn = new SqlConnection(connectionString))
                {

                    using (SqlCommand cmd = new SqlCommand("DscSprProductsUpdate", cnn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@Id", System.Data.SqlDbType.Int) { Value = id, Direction = System.Data.ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter("@Foto", System.Data.SqlDbType.NVarChar) { Value = request.Foto, Size = -1, Direction = System.Data.ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter("@Nombre", System.Data.SqlDbType.NVarChar) { Value = request.Nombre, Size = 200, Direction = System.Data.ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter("@Talla", System.Data.SqlDbType.NVarChar) { Value = request.Talla, Size = 50, Direction = System.Data.ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter("@EstatusCabezaId", System.Data.SqlDbType.Int) { Value = request.EstatusCabezaId, Direction = System.Data.ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter("@CongelamientoId", System.Data.SqlDbType.Int) { Value = request.CongelamientoId, Direction = System.Data.ParameterDirection.Input });
                        cmd.Parameters.Add(new SqlParameter("@MarcaId", System.Data.SqlDbType.Int) { Value = request.MarcaId, Direction = System.Data.ParameterDirection.Input });



                        await cnn.OpenAsync();
                        int files = await cmd.ExecuteNonQueryAsync();
                        return (files > 0);
                    }

                }



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
