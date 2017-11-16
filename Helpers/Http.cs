using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspNetCoreWebAPI.Helpers
{
    public class Http
    {          
        public static async Task<string> Get(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            
            string content = await response.Content.ReadAsStringAsync();
            
            return content;
        } 
        
        public static async Task<string> Post(string url, Dictionary<string, string> payload)
        {

            //new Dictionary<string, string>
            //{
            //    {"foo", "bar"},
            //    {"fizz", "buzz"}
            //};
                
            var formContent = new FormUrlEncodedContent(payload);
         
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(url, formContent);

            string content = await response.Content.ReadAsStringAsync();
            
            return content;
        }
    }
}