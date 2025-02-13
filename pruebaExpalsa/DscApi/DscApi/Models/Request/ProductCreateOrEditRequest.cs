namespace DscApi.Models.Request
{
    public class ProductCreateOrEditRequest
    {
        public string Foto { get; set; }
        public string Nombre { get; set; }
        public int EstatusCabezaId { get; set; }
        public string Talla { get; set; }
        public int CongelamientoId { get; set; }
        public int MarcaId { get; set; }
    }
}
