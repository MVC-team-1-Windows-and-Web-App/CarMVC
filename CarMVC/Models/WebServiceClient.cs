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
        HttpClient client = new HttpClient();

        public List<ApiCustomer> GetCustomers()
        {

            //replace local host with 172.30.0.10
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


            return null;
        }

        public ApiCustomer GetCustomer(int id)
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


            return null;

        }

        public bool CreateCustomer(ApiCustomer customer)
        {
            client.BaseAddress = new Uri("http://localhost:81/");

            var postTask = client.PostAsJsonAsync("api/Customer",customer);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else {
                return false;
            }
            

        }

        public bool UpdateCustomer(ApiCustomer customer)
        {
            client.BaseAddress = new Uri("http://172.30.0.10:81/api/Values/");

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