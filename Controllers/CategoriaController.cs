using Microsoft.AspNetCore.Mvc;
using testAPI.Context;
using testAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ConexionSQLServer context;

        public CategoriaController(ConexionSQLServer context)
        {
            this.context = context;
        }

        [HttpGet("Read")]
        public ActionResult<List<Categorium>> Get()
        {
            var result = context.Categoria.ToList();
            return result;
        }

        [HttpPost("Create")]
        public void Post([FromBody] Categorium categorium)
        {
            using (var transaccion = context.Database.BeginTransaction())
            {
                try
                {
                    context.Add(categorium);
                    context.SaveChanges();
                    transaccion.Commit();
                }
                catch (Exception)
                {
                    transaccion.Rollback();
                }
            }
        }
        [HttpPost("Creates")]
        public void PostNuevo([FromBody] Categorium categorium)
        {
            try
            {
                using (var transaccion = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Add(categorium);
                        context.SaveChanges();
                        transaccion.Commit();
                    }
                    catch (Exception)
                    {
                        transaccion.Rollback();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

            [HttpPut("{id}")]
        public void Put(int id, [FromBody] Categorium unaCategoria)
        {
            using (var transaccion = context.Database.BeginTransaction())
            {
                try
                {
                    var unDato = context.Categoria.Where(c => c.CategoriaId == id).First();
                    if (unDato != null)
                    {
                        unDato.Nombre = unaCategoria.Nombre;
                        context.SaveChanges();
                        transaccion.Commit();
                    }

                }
                catch (Exception)
                {
                    transaccion.Rollback();
                }
            }
        }
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var unDato = await context.Categoria.FindAsync(id);
            if (unDato == null)
            {
                return false;
            }
            context.Categoria.Remove(unDato);
            context.SaveChanges();
            return true;
        }
        
    }
}
