using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADNCORE_MUD.Shared.Models;

namespace ADNCORE_MUD.Client.Data.Interfaces
{
    public interface IVclienteService
    {
        Task<IList<vcliente>> Get();
        Task<vcliente?> Get(int? id);
        Task Put(vcliente request);
        Task Post(vcliente request);
        Task Delete(int id);
    }
}