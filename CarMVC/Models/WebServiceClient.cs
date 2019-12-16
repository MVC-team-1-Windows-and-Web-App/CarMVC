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
            client.BaseAddress = new Uri("http://localhost:81/");

            // Note you must do:
            // install-package Microsoft.AspNet.WebApi.Client
            // For the below to work.

            //HTTP GET
            var responseTask = client.GetAsync("api/Customer");
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

            client.BaseAddress = new Uri("http://localhost:81/");

            //HTTP GET
            var responseTask = client.GetAsync("api/Customer/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<ApiCustomer>();
                readTask.Wait();
                var customer = readTask.Result;

                return customer;
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
            client.BaseAddress = new Uri("http://localhost:81/");

            var putTask = client.PutAsJsonAsync<ApiCustomer>("api/Customer/" + customer.CustomerId, customer);
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

        public bool DeleteCustomer(int id)
        {
            client.BaseAddress = new Uri("http://localhost:81/");

            var deleteTask = client.DeleteAsync("api/Customer/" + id);
            deleteTask.Wait();
            var result = deleteTask.Result;
            if (result.IsSuccessStatusCode) {
                return true;
            }
            else {
                return false;
            }

        }

        public List<ApiSale> GetSales() {
            client.BaseAddress = new Uri("http://localhost:81/");

            var responseTask = client.GetAsync("api/Sale/");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<ApiSale[]>();
                readTask.Wait();
                var sales = readTask.Result;

                return sales.ToList();
            }
            else
                return new List<ApiSale>();
        }

        public bool CreateSale (ApiSale sale)
        {
            client.BaseAddress = new Uri("http://localhost:81/");

            var postTask = client.PostAsJsonAsync("api/Sale", sale);
            postTask.Wait();
            var result = postTask.Result;
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