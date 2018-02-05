using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MVC5.App_Code
{
    public class RESTClient
    {
        public RESTClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        private string _baseUrl { get; set; }

        public async Task<T> Get<T>(string url) where T : class
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(_baseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage Res = await client.GetAsync(url);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var response = await Res.Content.ReadAsStringAsync();

                    ////Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<T>(response);

                }
                else
                {
                    //Storing the response details recieved from web api   
                    var response = await Res.Content.ReadAsStringAsync();

                    throw new Exception(response);
                }
            }
        }

        public async Task<T> PostJson<T>(string url, object model) where T : class
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(_baseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Serialize our concrete class into a JSON String
                var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(model));

                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

                HttpResponseMessage Res = await client.PostAsync(url, httpContent);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var response = await Res.Content.ReadAsStringAsync();

                    ////Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<T>(response);

                }
                else
                {
                    //Storing the response details recieved from web api   
                    var response = await Res.Content.ReadAsStringAsync();

                    throw new Exception(response);
                }
            }
        }

        public async Task<T> PutJson<T>(string url, object model) where T : class
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(_baseUrl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Serialize our concrete class into a JSON String
                var stringPayload = await Task.Run(() => JsonConvert.SerializeObject(model));

                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

                HttpResponseMessage Res = await client.PutAsync(url, httpContent);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var response = await Res.Content.ReadAsStringAsync();

                    ////Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<T>(response);

                }
                else
                {
                    //Storing the response details recieved from web api   
                    var response = await Res.Content.ReadAsStringAsync();

                    throw new Exception(response);
                }
            }
        }        

        public async Task<T> Delete<T>(string url) where T : class
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(_baseUrl);

                client.DefaultRequestHeaders.Clear();

                HttpResponseMessage Res = await client.DeleteAsync(url);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var response = await Res.Content.ReadAsStringAsync();

                    ////Deserializing the response recieved from web api and storing into the Employee list  
                    return JsonConvert.DeserializeObject<T>(response);

                }
                else
                {
                    //Storing the response details recieved from web api   
                    var response = await Res.Content.ReadAsStringAsync();

                    throw new Exception(response);
                }
            }
        }
    }
}