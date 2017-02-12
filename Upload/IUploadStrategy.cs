using System.Net.Http;

namespace ESDotNetClient.Upload
{
    public interface IUploadStrategy
    {
         void Upload(HttpClient client, int size);
         string GetStrategyName();
    }
}