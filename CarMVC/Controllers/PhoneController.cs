using CarMVC.Models;
using CarMVCClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarMVC.Controllers
{
    public class PhoneController : Controller
    {

        WebServiceClient client = new WebServiceClient();


        // GET: Phone
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Phones()
        {
            List<ApiPhone> phones = client.GetPhones();
            return View(phones);
        }

        public ActionResult Create()
        {
            return View();
        }

        //Toddo
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            ApiPhone phone = new ApiPhone()
            {

                PhoneId = Convert.ToInt32(form["PhoneId"]),
                PhoneNumber = form["PhoneNumber"].ToString(),

           
            };

            if (client.CreatePhone(phone))
            {
                return RedirectToAction("Phones");
            }
            else
            {
                return View(phone);
            }


        }

        public ActionResult Delete(int id)
        {
            ApiPhone phone = client.GetPhone(id);


            return View(phone);

            //client.DeletePhone(id);
            //return RedirectToAction("Phones");
        }

        [HttpPost]
        public ActionResult Delete(int id, bool? del)
        {

            if (client.DeletePhone(id))
            {
                ViewBag.message = "Phone iphone vertook them";
            }
            else
            {
                ViewBag.message = "Android Sell";
            }
            return RedirectToAction("Phones");
        }



        public ActionResult Details(int id)
        {
            return View(client.GetPhone(id));
        }

        public ActionResult Edit(int id)
        {
            return View(client.GetPhone(id));
        }

        [HttpPost]
        public ActionResult Edit(ApiPhone phone)
        {
            if (client.UpdatePhone(phone))
            {
                ViewBag.message = "Phone Changed";
            }
            else
            {
                ViewBag.message = "Phone not Changed, error";
            }
            return RedirectToAction("Details", new { id = phone.PhoneId });
        }

    }
}