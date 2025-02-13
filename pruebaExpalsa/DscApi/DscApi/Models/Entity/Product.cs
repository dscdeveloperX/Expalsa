namespace DscApi.Models.Entity
{
    public class Product
    {
        public int? Id { get; set; }
        public string Foto { get; set; }
        public string Nombre { get; set; }
        public int EstatusCabezaId { get; set; }
        public string? EstatusCabezaName { get; set; }
        public string Talla { get; set; }
        public int CongelamientoId { get; set; }
        public string? CongelamientoName { get; set; }
        public int MarcaId { get; set; }
        public string? MarcaName { get; set; }

    }
}
