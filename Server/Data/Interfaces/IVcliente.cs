using ADNCORE_MUD.Shared.Models;

namespace ADNCORE_MUD.Server.Data.Interfaces
{
    public interface IVcliente
    {
        public IQueryable<vcliente> GetAll();
        public Task<vcliente> GetbyID(int id);
        public Task DeleteAsync(int id);
        public Task UpdateAsync(vcliente vcliente);
        public Task CreateAsync(vcliente vcliente);
        public Tuple<int, int> Pagination(IQueryCollection queryString, IQueryable<vcliente> data);
        public IQueryable<vcliente> Search(string filter);
    }

}