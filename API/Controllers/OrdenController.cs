using Microsoft.AspNetCore.Mvc;
using Tienda.Models;
using Tienda.UnitOfWork;

namespace API.Controllers
{
    [ApiController]
    [Route("orden")]
    public class OrdenController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrdenController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("crear")]
        public IActionResult crearOrden([FromBody] Orden orden)
        {
            return Ok(_unitOfWork.Orden.FunctionCrearOrder("crearOrden",orden.Cedula,orden.Direccion,orden.Total));
        }

        [HttpPost]
        [Route("ordenProducto")]
        public IActionResult crearOrdenProducto([FromBody] OrdenProducto orden)
        {
            return Ok(_unitOfWork.Orden.FunctionCrearOrderProducto("crearOrdenProducto", orden.Orden_id, orden.Producto_id, orden.Cantidad));
        }

        [HttpPost]
        [Route("guardar")]
        public IActionResult guardarOrden([FromBody] Orden orden)
        {
            return Ok(_unitOfWork.Orden.FunctionGuardarOrder("guardar",orden.NumeroOrden, orden.Cedula, orden.Direccion, orden.Total));
        }




    }
}
