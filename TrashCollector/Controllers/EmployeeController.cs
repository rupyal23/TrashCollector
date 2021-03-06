﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext context;
        public EmployeeController()
        {
            context = new ApplicationDbContext();
            
        }
        // GET: Employee
        //Get a default list of pickups matchin the employee zip code
        public ActionResult Index()
        {
            var userLoggedIn = User.Identity.GetUserId();
            var today = DateTime.Today.DayOfWeek;
            var employee = context.Employees.SingleOrDefault(e => e.AppicationUserId == userLoggedIn);
            var pickups = context.Pickups.Where(z => z.Customer.Address.Zip == employee.Zip).Where(e =>e.PickupDay == today).ToList();

            return View(pickups);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                var userLoggedIn = User.Identity.GetUserId();
                var employee = context.Employees.SingleOrDefault(e => e.AppicationUserId == userLoggedIn);
                var pickup = context.Pickups.SingleOrDefault(z => z.Id == id);
                var customer = context.Customers.SingleOrDefault(c => c.Id == pickup.CustomerId);
                var address = context.Addresses.SingleOrDefault(a => a.Id == customer.AddressId);
                var viewModel = new CustomerAddressViewModel
                {
                    Customer = customer,
                    Address = address,
                    Pickup = pickup
                };
                return View("Details", viewModel);
            }
            catch
            {
                return View();
            }
          
            
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                employee.AppicationUserId = User.Identity.GetUserId();
                context.Employees.Add(employee);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                var userLoggedIn = User.Identity.GetUserId();
                var employeeFromDb = context.Employees.SingleOrDefault(c => c.AppicationUserId == userLoggedIn);
                employeeFromDb.Zip = employee.Zip;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
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


        //Get
        public ActionResult SelectPickup()
        {
            var userLoggedIn = User.Identity.GetUserId();
            var employee = context.Employees.SingleOrDefault(c => c.AppicationUserId == userLoggedIn);
            var viewModel = new EmployeeViewModel
            {
                Employee = employee,
                Day = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", "All"}
            };
            return View(viewModel);
        }

        //Post
        
        [HttpPost]
        public ActionResult SelectPickup(EmployeeViewModel Model)
        {
            string text = Model.Day.ElementAt(0);
            var userLoggedIn = User.Identity.GetUserId();
            var employee = context.Employees.SingleOrDefault(e => e.AppicationUserId == userLoggedIn);
            var pickups = context.Pickups.Where(z => z.Customer.Address.Zip == employee.Zip).ToList();

            if (text != "" && text != "All")
            {
                var filteredPickups = pickups.Where(z => z.PickupDay.ToString() == text).ToList();
                //var filteredPickupsTwo = pickups.Where(a => a.SecondPickupDay.ToString() == text).ToList();
               // filteredPickups.AddRange(filteredPickupsTwo);
                return View("Index", filteredPickups);

            }

            return View("Index", pickups);
        }

        public ActionResult ConfirmPickup(int id)
        {
            var pickupToConfirm = context.Pickups.SingleOrDefault(a => a.Id == id);
            int customerId = pickupToConfirm.CustomerId;
            pickupToConfirm.Status = "completed";
            var customer = context.Customers.Where(a => a.Id == customerId).SingleOrDefault();
            customer.Balance += 5;
            customer.TotalPickups += 1;
            var parentPickup = context.Pickups.Where(p => p.SecondPickupDate == pickupToConfirm.PickupDate).SingleOrDefault();
            if(parentPickup != null)
                parentPickup.SecondPickupDate = null;
            context.SaveChanges();
            var userLoggedIn = User.Identity.GetUserId();
            var employee = context.Employees.SingleOrDefault(e => e.AppicationUserId == userLoggedIn);
            var pickups = context.Pickups.Where(z => z.Customer.Address.Zip == employee.Zip).ToList();
            return View("Index", pickups);
        }

        //Made for viewing all customers on a map
        public ActionResult ViewAll(DayOfWeek text)
        {
            var userLoggedIn = User.Identity.GetUserId();
            var employee = context.Employees.SingleOrDefault(e => e.AppicationUserId == userLoggedIn);
            var pickups = context.Pickups.Where(z => z.Customer.Address.Zip == employee.Zip).Where(e => e.PickupDay == text).ToList();
            return View(pickups);
        }

        //Just Made logic to refresh pickup at end of week, not implemented anywhere yet
        public void RefreshPickup(Pickup pickup)
        {
            DateTime dt = DateTime.Now;
            if(dt.DayOfWeek.ToString() == "Sunday")
            {
                pickup.Status = "Not-completed";
                pickup.PickupDate.Value.AddDays(7);
                context.SaveChanges();
            }
        }
    }
}