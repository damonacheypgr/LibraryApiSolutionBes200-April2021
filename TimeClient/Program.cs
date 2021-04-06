using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TimeClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var client = new HttpClient();

            client.BaseAddress = new Uri("http://localhost:1337");

            while (true)
            {
                var response = await client.GetAsync("/servertime");

                Console.WriteLine(response.Headers.CacheControl.ToString());

                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);

                Console.WriteLine("Continue");
                var q = Console.ReadLine();

                if (q == "q") break;
            }
        }
    }
}
