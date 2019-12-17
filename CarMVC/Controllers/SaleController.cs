using CarMVC.Models;
using CarMVCClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMVC.Controllers
{
    public class SaleController : Controller
    {
        WebServiceClient client = new WebServiceClient();

        // GET: Sale
        public ActionResult Sales()
        {
            List<ApiSale> sales = client.GetSales();
            return View(sales);
        }

        public ActionResult Create() {
            return View();
        }


        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            ApiSale sale = new ApiSale()
            {
                CustomerId = Int32.Parse(form["CustomerId"]),
                CarId = Int32.Parse(form["CarId"]),
                SalesPersonId = Int32.Parse(form["SalesPersonId"]),
                SaleDate = DateTime.Parse(form["SaleDate"]),
                SaleQuantity = Int32.Parse(form["SaleQuantity"]),
                SaleTotal = Decimal.Parse(form["SaleTotal"]),
            };            

            if (client.CreateSale(sale))
            {
                return RedirectToAction("Sales");
            }
            else
            {
                return View(sale);
            }
        }

        public ActionResult Delete(int id)
        {
            ApiSale sale = client.GetSale(id);

            return View(sale);
        }

        [HttpPost]
        public ActionResult Delete(int id, bool? del)
        {

            if (client.DeleteSale(id))
            {
                ViewBag.message = "Sale Nuked";
            }
            else
            {
                ViewBag.message = "Could Not Nuke Sale";
            }
            return RedirectToAction("Sales");
        }

        public ActionResult Details(int id)
        {
            return View(client.GetSale(id));
        }

        public ActionResult Edit(int id)
        {
            return View(client.GetSale(id));
        }

        [HttpPost]
        public ActionResult Edit(ApiSale sale)
        {
            if (client.UpdateSale(sale))
            {
                ViewBag.message = "Sale Changed";
            }
            else
            {
                ViewBag.message = "Sale not Changed, error";
            }
            return RedirectToAction("Details", new { id = sale.SaleId });
        }
    }
}