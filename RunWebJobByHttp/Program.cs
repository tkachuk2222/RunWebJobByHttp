using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RunWebJobByHttp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("https://[website name].scm.azurewebsites.net/api/");

            var byteArray = Encoding.ASCII.GetBytes("[username:password]"); // username and pass from WebJob properties(username starts with "$")

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var response = await client.PostAsync("triggeredwebjobs/[WebJob name]/run", null);
        }
    }
}
