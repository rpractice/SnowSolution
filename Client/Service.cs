using System;
using System.Net.Http;

using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public static class Service
    {
        private static readonly string baseUrl = "http://localhost:5000/";
        private static readonly string apiCall = "api/natssubject";
        public static async Task<string> GetMessage()
        {
            string message = "";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = await client.GetAsync("api/natssubject");
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        message = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                return message;
            }

            return message;
        }

        public static async Task<bool> SendMessage(string message)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    StringContent content = new StringContent(message, Encoding.UTF8, "application/json");
                    var response = client.PostAsJsonAsync(apiCall, message).Result;
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        message = await response.Content.ReadAsStringAsync();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
