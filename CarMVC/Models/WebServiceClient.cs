using CarMVCClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarMVC.Models
{
    class WebServiceClient
    {
        public List<ApiCustomer> GetCustomers()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:81/api/Customer");

                // Note you must do:
                // install-package Microsoft.AspNet.WebApi.Client
                // For the below to work.

                //HTTP GET
                var responseTask = client.GetAsync("/api/Customer");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ApiCustomer[]>();
                    readTask.Wait();
                    var customers = readTask.Result;

                    return customers.ToList();
                }
            }

            return null;
        }

        public ApiCustomer GetCustomer(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:81/api/Customer/");

                //HTTP GET
                var responseTask = client.GetAsync("/api/Customer/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ApiCustomer>();
                    readTask.Wait();
                    var student = readTask.Result;

                    return student;
                }
            }

            return null;

        }

        public bool UpdateCustomer(ApiCustomer customer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:81/api/Values/");

                var putTask = client.PutAsJsonAsync<ApiCustomer>("/api/Customer/" + customer.CustomerId, customer);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }
    }
}