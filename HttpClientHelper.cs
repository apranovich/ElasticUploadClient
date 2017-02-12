using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ESDotNetClient
{
    public static class HttpClientHelper
    {
        public static async Task<HttpResponseMessage> PostAsJsonAsync(this HttpClient client, string requestUrl, string payload)
        {
            var stringContent = new StringContent(payload, Encoding.UTF8, "application/json");
            return await client.PostAsync(requestUrl, stringContent);
        }
    }
}