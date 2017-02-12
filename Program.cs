using ESDotNetClient;
using ESDotNetClient.Upload;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string baseUri = "http://localhost:9200/";
            int size = 100000;

            IUploadStrategy uploadStrategy = new BulkUpload(); 
            var esClient = new ElasticSearchDataClient(uploadStrategy);
            esClient.Upload(baseUri, size);

            esClient.SetUploadingStrategy(new SingleRequestUpload());
            esClient.Upload(baseUri, size);
        }
    }
}
