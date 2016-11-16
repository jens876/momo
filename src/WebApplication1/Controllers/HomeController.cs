using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace WebApplication1.Controllers
{


    public class Product
    {
        public String name;
    }
    public class HomeController : Controller
    {
        static HttpClient m_httpClient = new HttpClient();

		public String GetApiUrl()
		{
			HttpRequest x = HttpContext.Request;
			return x.Scheme + "://" + x.Host +  x.PathBase + "/api/data";
		}

        public IActionResult Index()
        {
			ViewData["apiUrl"] = GetApiUrl();
			return View();
        }

		public IActionResult Jens()
		{
			HttpRequest x = HttpContext.Request;
			String apiUrl = GetApiUrl();
			Task<string> task = GetProductAsync(apiUrl+"/111");
			task.Wait();

			ViewData["Message"]= apiUrl;
			ViewData["Response"] = task.Result;
			ViewData["apiUrl"] = GetApiUrl();

			return View();
		}

		public IActionResult About()
        {

            Product product = new Product();
            product.name = "Apple";
            //product.ExpiryDate = new DateTime(2008, 12, 28);
            //product.Price = 3.99M;
            //product.Sizes = new string[] { "Small", "Medium", "Large" };

            string output = JsonConvert.SerializeObject(product);

            ViewData["Message"] = "Your application description page.";
			ViewData["apiUrl"] = GetApiUrl();


			return View();
        }


        /*public async Task<string> GetGreetingAsync()
        {
            using (var client = new HttpClient())
            {
                var response =
                    await client.GetStringAsync("http://localhost:5000/api/tc");
                // The response object is a string that looks like this:
                // "{ message: 'Hello world!' }"
            }
        }*/


        static async Task<String> GetProductAsync(string path)
        {
            String sproduct = "";
            HttpResponseMessage response = await m_httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                sproduct = await response.Content.ReadAsStringAsync();
            }
            return sproduct;
        }

        public IActionResult Contact()
        {
            HttpRequest x = HttpContext.Request;
            String myPathToUse = x.Scheme + "://" + x.Host + x.PathBase + "/api/tc";
            Task<string> task = GetProductAsync(myPathToUse);
            task.Wait();

            ViewData["Message"] = task.Result;

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult func1()
        {
            return About();

        }
    }
}
