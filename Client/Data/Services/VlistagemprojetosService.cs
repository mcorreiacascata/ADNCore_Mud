using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

using ADNCORE_MUD.Shared.Models;
using ADNCORE_MUD.Client.Data.Interfaces;

namespace ADNCORE_MUD.Client.Data.Services
{
    public class VclienteService:IVclienteService
    {
        private readonly HttpClient httpClient;
        
        public VclienteService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        
        public async Task<IList<vcliente>> Get()
        {
            var response = await httpClient.GetAsync("api/vcliente");
            response.EnsureSuccessStatusCode();
            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<List<vcliente>>(responseContent);
        }
        
        public async Task<vcliente?> Get(int? id)
        {
            return await httpClient.GetFromJsonAsync<vcliente>($"/api/vcliente/{id}");
        }

        public async Task Put(vcliente element)
        {
            await httpClient.PutAsJsonAsync("/api/vcliente", element);
        }
        
        public async Task Post(vcliente element)
        {
            await httpClient.PostAsJsonAsync("/api/vcliente", element);
        }
        
        public async Task Delete(int id)
        {
            await httpClient.DeleteAsync($"/api/vcliente/{id}");
        }
    }
}