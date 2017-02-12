using System;
using System.Diagnostics;
using System.Net.Http;
using ESDotNetClient.Upload;

namespace ESDotNetClient
{
    public class ElasticSearchDataClient
    {
        private IUploadStrategy uploadStrategy;

        public ElasticSearchDataClient(IUploadStrategy uploadStrategy)
        {
            this.uploadStrategy = uploadStrategy;
        }

        public void SetUploadingStrategy(IUploadStrategy uploadStrategy)
        {
            this.uploadStrategy = uploadStrategy;
        }

        public void Upload(string baseUri, int size)
        {
            using (var client = new HttpClient())
            {   
                Stopwatch sw = new Stopwatch();

                client.BaseAddress = new Uri(baseUri);   
                
                sw.Start();
                uploadStrategy.Upload(client, size);
                sw.Stop();

                Console.WriteLine($"{uploadStrategy.GetStrategyName()}: elapsed time={sw.Elapsed}");
            }
        }
    }
}