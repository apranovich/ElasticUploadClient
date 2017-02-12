using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ESDotNetClient.Upload
{
    public class SingleRequestUpload : IUploadStrategy
    {
        public string GetStrategyName()
        {
            return "Multiple HTTP requests";
        }

        public void Upload(HttpClient client, int size)
        {
            for(int i=1; i<=size; i++)
            {
                var response = client.PostAsJsonAsync("users/user/", PrepareSinglePayload(i)).Result;

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
        }

        private string PrepareSinglePayload(int i)
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            string json = JsonConvert.SerializeObject(ValueHelpers.GenerateUser(i.ToString()), serializerSettings);
            return json;
        }
    }
}