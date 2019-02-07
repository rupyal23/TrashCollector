using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext context;

        public CustomerController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Customer
        public ActionResult Index()
        {

            return View();
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            var viewModel = new CustomerAddressViewModel
            {
                Customer = new Customer(),
                Address = new Address()
            };
            return View(viewModel);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(CustomerAddressViewModel viewModel)
        {
            try
            {
                //Seed Address First in Database
                context.Addresses.Add(viewModel.Address);
                context.SaveChanges();
                //Set Customer Address FK to Address Id
                viewModel.Customer.AddressId = viewModel.Address.Id;
                //Get User Id keyed to the customer Application User Id
                viewModel.Customer.AppicationUserId = User.Identity.GetUserId();
                //Now Add Customer to database
                context.Customers.Add(viewModel.Customer);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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
