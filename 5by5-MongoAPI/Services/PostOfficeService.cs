using _5by5_MongoAPI.Models;
using Newtonsoft.Json;

namespace _5by5_MongoAPI.Services
{
    public class PostOfficeService
    {
        static readonly HttpClient address = new HttpClient();
    
        public static async Task<AddressDTO> GetAddress(string zipCode)
        {
            try
            {
                var response = await address.GetAsync($"https://viacep.com.br/ws/{zipCode}/json/");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<AddressDTO>(content);
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }
    }
}