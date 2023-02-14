using Microsoft.AspNetCore.Mvc;
using testAPI.Context;
using testAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ConexionSQLServer context;

        public ProductoController(ConexionSQLServer context)
        {
            this.context = context;
        }
        [HttpGet("Read")]
        public ActionResult<List<Producto>> Get()
        {
            var result = context.Productos.ToList();
            if(result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();    
            }
            
        }
        [HttpPost("Create")]
        public void Post([FromBody] Producto unProducto)
        {
            using (var transaccion = context.Database.BeginTransaction())
            {
                try
                {
                    context.Add(unProducto);
                    context.SaveChanges();
                    transaccion.Commit();
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                }
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
