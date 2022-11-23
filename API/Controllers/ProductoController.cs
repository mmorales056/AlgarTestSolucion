using Microsoft.AspNetCore.Mvc;
using Tienda.Models;
using Tienda.UnitOfWork;

namespace API.Controllers
{
    [ApiController]
    [Route("productos")]
    public class ProductoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unitOfWork.Producto.GetList());
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            return Ok(_unitOfWork.Producto.GetById(id));
        }
      

        [HttpPost]
        public IActionResult Post([FromBody] Producto producto)
        {
            if (!ModelState.IsValid) return BadRequest();
            return Ok(_unitOfWork.Producto.Insert(producto));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Producto producto)
        {
            if (ModelState.IsValid && _unitOfWork.Producto.Update(producto))
            {
                return Ok(new { Message = "The Produto fue actualizado" });

            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Producto producto)
        {
            if (producto.Id > 0)
                return Ok(_unitOfWork.Producto.Delete(producto));

            return BadRequest();
        }
    }
}
