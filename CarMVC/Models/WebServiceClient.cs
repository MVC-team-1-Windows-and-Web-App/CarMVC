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
            client.BaseAddress = new Uri("http://172.30.0.10/");

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

            //
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



        /// <summary>
        ///Sales 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>


        public ApiSale GetSale(int id)
        {
            client.BaseAddress = new Uri("http://localhost:81/");

            //HTTP GET
            var responseTask = client.GetAsync("api/Sale/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<ApiSale>();
                readTask.Wait();
                var sale = readTask.Result;

                return sale;
            }


            return null;
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


        public bool DeleteSale(int id)
        {
            client.BaseAddress = new Uri("http://localhost:81/");

            var deleteTask = client.DeleteAsync("api/Sale/" + id);
            deleteTask.Wait();
            var result = deleteTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
   

        public bool UpdateSale(ApiSale sale)
        {
            client.BaseAddress = new Uri("http://localhost:81/");

            var putTask = client.PutAsJsonAsync<ApiSale>("api/Sale/" + sale.CustomerId, sale);
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

        //Salesperson 
        public ApiSalesperson GetSalesperson(int id)
        {
            client.BaseAddress = new Uri("http://localhost:81/");

            var responseTask = client.GetAsync("api/Salesperson/" + id);

        public List<ApiLocation> GetLocations()
        {
            client.BaseAddress = new Uri("http://localhost:81/");

            var responseTask = client.GetAsync("api/Location");

            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<ApiSalesperson>();
                readTask.Wait();
                var salesperson = readTask.Result;

                return salesperson;
            }


            return null;
        }

        public List<ApiSalesperson> GetSalespersons()
        {
            client.BaseAddress = new Uri("http://localhost:81/");

            var responseTask = client.GetAsync("api/Salesperson/");

                var readTask = result.Content.ReadAsAsync<ApiLocation[]>();
                readTask.Wait();
                var locations = readTask.Result;

                return locations.ToList();
            }
            return null;
        }

        public ApiLocation GetLocation(int id)
        {
            client.BaseAddress = new Uri("http://localhost:81/");

            var responseTask = client.GetAsync("api/Location/" + id);

            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<ApiSalesperson[]>();
                readTask.Wait();
                var salesperson = readTask.Result;

                return salesperson.ToList();
            }
            else
                return new List<ApiSalesperson>();
        }

        public bool CreateSalesperson(ApiSalesperson salesperson)
        {
            client.BaseAddress = new Uri("http://localhost:81/");

            var postTask = client.PostAsJsonAsync("api/Salesperson", salesperson);

                var readTask = result.Content.ReadAsAsync<ApiLocation>();
                readTask.Wait();
                var location = readTask.Result;

                return location;
            }


            return null;

        }

        public bool CreateLocation(ApiLocation location)
        {
            client.BaseAddress = new Uri("http://localhost:81/");

            var postTask = client.PostAsJsonAsync("api/Location", location);

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


        public bool DeleteSalesperson(int id)
        {
            client.BaseAddress = new Uri("http://localhost:81/");

            var deleteTask = client.DeleteAsync("api/Salesperson/" + id);
            deleteTask.Wait();
            var result = deleteTask.Result;



        }

        public bool UpdateLocation(ApiLocation location)
        {
            client.BaseAddress = new Uri("http://localhost:81/");

            var putTask = client.PutAsJsonAsync<ApiLocation>("api/Location/" + location.LocationId, location);
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

        public bool UpdateSalesperson(ApiSalesperson salesperson)
        {
            client.BaseAddress = new Uri("http://localhost:81/");

            var putTask = client.PutAsJsonAsync<ApiSalesperson>("api/Salesperson/" + salesperson.SalespersonId, salesperson);
            putTask.Wait();
            var result = putTask.Result;

        public bool DeleteLocation(int id)
        {
            client.BaseAddress = new Uri("http://localhost:81/");

            var deleteTask = client.DeleteAsync("api/Location/" + id);
            deleteTask.Wait();
            var result = deleteTask.Result;

            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        //Inventory (Car)


        }


        /// <summary>
        ///         Cars need to be tested 
        /// </summary>
        /// <param name="sale"></param>
        /// <returns></returns>



        public ApiCar GetCar(int id)
        {
            client.BaseAddress = new Uri("http://localhost:81/");

            //HTTP GET
            var responseTask = client.GetAsync("api/Car/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<ApiCar>();
                readTask.Wait();
                var car = readTask.Result;

                return car;
            }


            return null;
        }

        public List<ApiCar> GetCars()
        {
            client.BaseAddress = new Uri("http://localhost:81/");

            var responseTask = client.GetAsync("api/Car/");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<ApiCar[]>();
                readTask.Wait();

                var car = readTask.Result;

                return car.ToList();

                var cars = readTask.Result;

                return cars.ToList();

            }
            else
                return new List<ApiCar>();
        }

        public bool CreateCar(ApiCar car)
        {
            client.BaseAddress = new Uri("http://localhost:81/");

            var postTask = client.PostAsJsonAsync("api/Car", car);
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



        public bool DeleteCar(int id)
        {
            client.BaseAddress = new Uri("http://localhost:81/");

            var deleteTask = client.DeleteAsync("api/Car/" + id);
            deleteTask.Wait();
            var result = deleteTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateCar(ApiCar car)
        {
            client.BaseAddress = new Uri("http://localhost:81/");

            var putTask = client.PutAsJsonAsync<ApiCar>("api/Car/" + car.CarId, car);
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