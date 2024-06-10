using Newtonsoft.Json;
using ProjMongoDBAPI.Models;

namespace ProjMongoDBAPI.Services
{
    public class PostOfficeServices
    {
        static readonly HttpClient address = new HttpClient();

        public static async Task<AddressDTO> GetAddress(string cep)
        {
            HttpResponseMessage response = await address.GetAsync($"https:/viacep.com.br/{cep}/json");
            response.EnsureSuccessStatusCode();
            string addr = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AddressDTO>(addr);
        }
    }
}
