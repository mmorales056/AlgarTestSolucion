using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Models;
using Tienda.Models.ModelDto;

namespace Tienda.Repositories
{
    public interface IOrdenRepository : IRepository<Orden>
    {
        IEnumerable<Orden> FunctionCrearOrder(string action, string cedula, string direccion, decimal total);
        IEnumerable<DetalleOrdenDto> FunctionCrearOrderProducto(string action, int orderId,int productoId, int cantidad);
        IEnumerable<Orden> FunctionGuardarOrder(string action, int numOrder, string cedula, string direccion, decimal total);

        

    }
}
