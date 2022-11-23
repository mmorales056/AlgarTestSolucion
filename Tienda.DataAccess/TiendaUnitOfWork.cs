using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Repositories;
using Tienda.UnitOfWork;

namespace Tienda.DataAccess
{
    public class TiendaUnitOfWork : IUnitOfWork
    {
        public TiendaUnitOfWork(string connectionString)
        {
            Producto = new ProductoRepository(connectionString);
            Orden= new OrdenRepository(connectionString);

        }
        public IProductoRepository Producto { get; private set; }

        public IOrdenRepository Orden { get; private set; } 
    }
}
