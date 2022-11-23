using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Models
{
    public class Orden
    {
        public int Id { get; set; }
        public int NumeroOrden { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public decimal Total { get; set; }
    }
}
