using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWebAPI_Consume
{
    class Program
    {
         
        static  void Main(string[] args)
        {
             
            Program p = new Program();
            p.Getall();
            Console.ReadKey();
        }

        public  async void Getall()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:2061/customers");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method  
                HttpResponseMessage response = await client.GetAsync("api/products/5");
                if (response.IsSuccessStatusCode)
                {
                    var product = await response.Content.ReadAsAsync<product0>();
                    Console.WriteLine("ProductName:{0}\tUnitPrice:{1}", product.ProductName, product.UnitPrice);
                    //Console.WriteLine("No of Employee in Department: {0}", );
                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }

        }

    }
}
