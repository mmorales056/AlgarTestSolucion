namespace Tienda.Models.ModelDto
{
    public class DetalleOrdenDto
    {
        public string NumeroOrden { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
