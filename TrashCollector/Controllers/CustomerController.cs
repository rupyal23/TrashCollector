﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var userLoggedIn = User.Identity.GetUserId();
            var customer = context.Customers.SingleOrDefault(c => c.AppicationUserId == userLoggedIn);
            return View("Details", customer);
        }

        // GET: Customer/Details/5
        public ActionResult Details()
        {
            var userLoggedIn = User.Identity.GetUserId();
            var customer = context.Customers.Include(a => a.Address).Where(c => c.AppicationUserId == userLoggedIn).SingleOrDefault();
            if(customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
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
                return RedirectToAction("Details", viewModel.Customer.Id);
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit()
        {
            var userLoggedIn = User.Identity.GetUserId();
            var customer = context.Customers.Include(a => a.Address).SingleOrDefault(c => c.AppicationUserId == userLoggedIn);
            if (customer == null)
                return HttpNotFound();
            return View("UpdatePickup", customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                var customerFromDb = context.Customers.Include(a => a.Address).SingleOrDefault(c => c.Id == customer.Id);
                //Add Changes - Add logic
                if (customer == null)
                    return HttpNotFound();

                context.SaveChanges();
                return View("Details", customer);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult UpdatePickup(int id)
        {
            try
            {
                var customer = context.Customers.Include(a => a.Address).SingleOrDefault(c => c.Id == id);
                if (customer == null)
                    return HttpNotFound();
                return View(customer);
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult UpdatePickup(Customer customer)
        {
            try
            {
                var userLoggedIn = User.Identity.GetUserId();
                var customerFromDb = context.Customers.Include(a => a.Address).SingleOrDefault(c => c.AppicationUserId == userLoggedIn);
                if (customerFromDb == null)
                    return HttpNotFound();
                var viewModel = new CustomerAddressViewModel
                {
                    Customer = customerFromDb,
                    Address = customerFromDb.Address
                };
                viewModel.Customer.PickUpDay = customer.PickUpDay;
                if(customer.SecondPickUpDay != null)
                    viewModel.Customer.SecondPickUpDay = customer.SecondPickUpDay;
                context.SaveChanges();
                return View("Index", viewModel);
            }
            catch
            {
                return View();
            }
        }

        public ViewResult SuspendService()
        {
            var userLoggedIn = User.Identity.GetUserId();
            var customer = context.Customers.SingleOrDefault(c => c.AppicationUserId == userLoggedIn);
            return View(customer);
        }

        [HttpPost]
        public ActionResult SuspendService(Customer customer)
        {
            try
            {
                var userLoggedIn = User.Identity.GetUserId();
                var customerFromDb = context.Customers.Include(a =>a.Address).SingleOrDefault(c => c.AppicationUserId == userLoggedIn);
                if(customerFromDb == null)
                {
                    return HttpNotFound();
                }
                var viewModel = new CustomerAddressViewModel
                {
                    Customer = customerFromDb,
                    Address = customerFromDb.Address
                };
                viewModel.Customer.SuspendStartDate = customer.SuspendStartDate;
                viewModel.Customer.SuspendEndDate = customer.SuspendEndDate;
                context.SaveChanges();
                return View("Index", viewModel);
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
        public ViewResult Balance(Customer customer)
        {
            var userLoggedIn = User.Identity.GetUserId();
            var customerFromDb = context.Customers.Include(m => m.Address).SingleOrDefault(a => a.AppicationUserId == userLoggedIn);
            return View("Details", customerFromDb);
        }

    }
}
