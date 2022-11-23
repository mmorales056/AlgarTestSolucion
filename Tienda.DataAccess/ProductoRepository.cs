using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Models;
using Tienda.Repositories;

namespace Tienda.DataAccess
{
    public class ProductoRepository:Repository<Producto>,IProductoRepository
    {
        public ProductoRepository(string connectionString) : base(connectionString)
        {
                
        }
    }
}
