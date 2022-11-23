using Dapper;
using System.Data.SqlClient;
using Tienda.Models;
using Tienda.Models.ModelDto;
using Tienda.Repositories;

namespace Tienda.DataAccess
{
    public class OrdenRepository : Repository<Orden>, IOrdenRepository
    {
        public OrdenRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<Orden> FunctionCrearOrder(string action, string cedula, string direccion, decimal total)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Action", action);
            parameters.Add("@Cedula", cedula);
            parameters.Add("@Direccion", direccion);
            parameters.Add("@Total", total);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Orden>("dbo.OrdenStoredProcedures", parameters, commandType: System.Data.CommandType.StoredProcedure);

            }
        }

        public IEnumerable<DetalleOrdenDto> FunctionCrearOrderProducto(string action, int orderId, int productoId, int cantidad)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Action", action);
            parameters.Add("@Orden_id", orderId);
            parameters.Add("@Producto_id", productoId);
            parameters.Add("@Cantidad", cantidad);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<DetalleOrdenDto>("dbo.OrdenStoredProcedures", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Orden> FunctionGuardarOrder(string action, int numOrder, string cedula, string direccion, decimal total)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Action", action);
            parameters.Add("@NumeroOrden", numOrder);
            parameters.Add("@Cedula", cedula);
            parameters.Add("@Direccion", direccion);
            parameters.Add("@Total", total);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Orden>("dbo.OrdenStoredProcedures", parameters, commandType: System.Data.CommandType.StoredProcedure);

            }
        }
    }
}
