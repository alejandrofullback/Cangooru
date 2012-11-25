using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cangooru.Services.Interfaces;
using CangooruMVC.Models;

namespace CangooruMVC.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        public OrderController(IOrderService service)
        {
            _orderService = service;
        }
        //
        // GET: /Order/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Order/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        [Authorize()]
        public ActionResult GetOrders()
        {

            return PartialView("Orders");
        }


        //
        // GET: /Order/Create

        public ActionResult Create()
        {
            CreateOrderModel model = new CreateOrderModel();
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "Documentos", Value = "0" });
            items.Add(new SelectListItem { Text = "Convites", Value = "1" });
            items.Add(new SelectListItem { Text = "Grana", Value = "2", Selected = true });
            items.Add(new SelectListItem { Text = "Droga", Value = "3" });
            ViewBag.DeliveryType = items;
            return PartialView("CreateOrder", model);
        }

        //
        // POST: /Order/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Order/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Order/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Order/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Order/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
