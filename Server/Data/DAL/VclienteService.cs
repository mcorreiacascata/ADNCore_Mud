using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using ADNCORE_MUD.Shared.Models;
using ADNCORE_MUD.Server.Data.Interfaces;
using ADNCORE_MUD.Server.Data.Context;

namespace ADNCORE_MUD.Server.Data.DAL
{
    public class VclienteService : IVcliente
    {
        CNGestaoProjetosTeste db = new CNGestaoProjetosTeste(); // RI BUSCAR DADOS AO ENTITY FRAMEWORK


        //************************************************* SECCÃO DE FUNÇÕES BASE (GET, GETBYID, CREATE, UPDATE, DELETE)
        public IQueryable<vcliente> GetAll()
        {
            var listagem = db.vcliente;

            return listagem;
        }

        public async Task<vcliente> GetbyID(int id)
        {   
            vcliente vcliente = await db.vcliente.Where(o => o.clienteId == id).FirstOrDefaultAsync();
            return vcliente;
        }


        public async Task CreateAsync(vcliente vcliente)
        {
            db.vcliente.Add(vcliente);
            await db.SaveChangesAsync();

        }


        public async Task UpdateAsync(vcliente vcliente)
        {
            db.Entry(vcliente).State = EntityState.Modified;
            await db.SaveChangesAsync();

        }


        public async Task DeleteAsync(int id)
        {
            vcliente? vcliente = db.vcliente.Find(id);
            db.vcliente.Remove(vcliente!);
            await db.SaveChangesAsync();

        }

        //************************************************* SECCÃO DE FUNÇÕES AUXILIARES (PESQUISAR, PAGINAÇÃO, ORDENAR)

        public Tuple<int, int> Pagination(IQueryCollection queryString, IQueryable<vcliente> data)
        {
            StringValues Skip;

            StringValues Take;

            int skip = (queryString.TryGetValue("$skip", out Skip)) ? Convert.ToInt32(Skip[0]) : 0;

            int top = (queryString.TryGetValue("$top", out Take)) ? Convert.ToInt32(Take[0]) : data.Count();

            return Tuple.Create(skip, top);
        }

        public IQueryable<vcliente> Search(string filter)
        {
            var data = db.vcliente;

            var newFiltersplits = filter;

            var filterSplits = newFiltersplits.Split(' ', '\'');

            string searchValue = filterSplits[1].ToString();

            Console.WriteLine(filterSplits[1]);

            var dadosFiltrados = data.Where(d => d.clienteNome.ToLower().Contains(searchValue)).AsQueryable();

            return dadosFiltrados;
        }

    }

}