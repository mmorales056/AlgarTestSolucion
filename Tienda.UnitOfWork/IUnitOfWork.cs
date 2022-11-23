using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Repositories;

namespace Tienda.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductoRepository Producto { get; }
        IOrdenRepository Orden { get; }
    }
}
