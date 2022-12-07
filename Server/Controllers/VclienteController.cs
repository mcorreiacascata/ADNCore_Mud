using Microsoft.AspNetCore.Mvc;
using ADNCORE_MUD.Server.Data.DAL;
using ADNCORE_MUD.Shared.Models;
using Microsoft.Extensions.Primitives;

namespace ADNCORE_MUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VclienteController : ControllerBase
    {
        VclienteService db = new VclienteService();

        // GET: api/vcliente
        [HttpGet]
        public Object GetVclientes()
        {
            IQueryable<vcliente> data = db.GetAll();

            var count = data.Count();

            var queryString = Request.Query;

            string filter = queryString["$filter"];

            if (filter != null) //************************************** PESQUISAR
            {

                IQueryable<Object> dadosFiltrados = db.Search(filter);

                if (queryString.Keys.Contains("$inlinecount"))
                {
                    var a = db.Pagination(queryString, data); // PAGINAÇÃO
                    return new { Items = dadosFiltrados.Skip(a.Item1).Take(a.Item2), Count = dadosFiltrados.Count() };
                }

                else
                {
                    return new { Items = dadosFiltrados, Count = dadosFiltrados.Count() };
                }   

            }


            if (queryString.Keys.Contains("$inlinecount"))
            {
                var a = db.Pagination(queryString, data); // PAGINAÇÃO

                return new { Items = data.Skip(a.Item1).Take(a.Item2), Count = count };
            }

            else
            {
                return data;
            }

        }


        // GET: api/vcliente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<vcliente>> GetVcliente(int id)
        {
            var vcliente = await db.GetbyID(id);

            if (vcliente == null)
            {
                return NotFound();
            }

            return vcliente;
        }


        // POST: api/vcliente
        [HttpPost]
        public async void PostVcliente([FromBody] vcliente vcliente)
        {
            await db.CreateAsync(vcliente);
        }


        // PUT: api/vcliente/5
        [HttpPut]
        public async Task<object> PutVcliente([FromBody] vcliente vcliente)
        {
            await db.UpdateAsync(vcliente);
            return vcliente;
        }


        // DELETE: api/vcliente/5
        [HttpDelete("{id}")]
        public async void DeleteVcliente(int id)
        {
            await db.DeleteAsync(id);
        }

    }
}