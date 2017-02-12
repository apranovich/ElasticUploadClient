using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ESDotNetClient.Upload
{
    public class BulkUpload : IUploadStrategy
    {
        public string GetStrategyName()
        {
            return "Bulk upload";
        }

        public void Upload(HttpClient client, int size)
        {
            var response = client.PostAsJsonAsync("users/user/_bulk", PrepareBulkPayload(size)).Result;

            if(response.IsSuccessStatusCode)
            {
                var responseContent = response.Content; 
                string responseString = responseContent.ReadAsStringAsync().Result;
            }
            else
            {
                System.Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
        }

        private string PrepareBulkPayload(int size)
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            var indexJson = new {Index = new object()};
            var serializedIndexJson = JsonConvert.SerializeObject(indexJson, serializerSettings);

            var payload = new StringBuilder();

            for(int i=1; i<=size; i++)
            {
                var user = ValueHelpers.GenerateUser(i.ToString());
                string userJson = JsonConvert.SerializeObject(user, serializerSettings);
                payload.Append(serializedIndexJson);
                payload.Append(Environment.NewLine);
                payload.Append(userJson);
                payload.Append(Environment.NewLine);
            }

            return payload.ToString();
        }
    }
}