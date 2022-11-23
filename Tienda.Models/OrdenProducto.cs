using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Models
{
    public class OrdenProducto
    {
        public int Id { get; set; }
        public int Orden_id { get; set; }
        public int Producto_id { get; set; }
        public int Cantidad { get; set; }
    }
}
