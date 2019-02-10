using Microsoft.AspNet.Identity;
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
            var pickup = context.Pickups.FirstOrDefault(p => p.CustomerId == customer.Id);
            var address = context.Addresses.SingleOrDefault(a => a.Id == customer.AddressId);

            var viewModel = new CustomerAddressViewModel
            {
                Customer = customer,
                Pickup = pickup,
                Address = address, 
                Day = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" }


            };
            return View(viewModel);
        }

        // GET: Customer/Details/5
        public ActionResult Details()
        {
            var userLoggedIn = User.Identity.GetUserId();
            var customer = context.Customers.Include(a => a.Address).Where(c => c.AppicationUserId == userLoggedIn).SingleOrDefault();
            if (customer == null)
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
                Address = new Address(),
                Pickup = new Pickup(),
                Day = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" }
            };
            return View(viewModel);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(CustomerAddressViewModel viewModel)
        {
            try
            {
                //Get Duplicate address from Db is any
                var addressFromDb = context.Addresses.Where(c => c.StreetNumber == viewModel.Address.StreetNumber).Where(d => d.StreetName == viewModel.Address.StreetName)
                    .Where(e => e.Zip == viewModel.Address.Zip).SingleOrDefault();
                if (addressFromDb != null)
                {
                    viewModel.Customer.AddressId = addressFromDb.Id;
                }
                else
                {
                    //Seed Address First in Database and Set PK id to FK address ID in customer
                    context.Addresses.Add(viewModel.Address);
                    context.SaveChanges();
                    viewModel.Customer.AddressId = viewModel.Address.Id;
                }
                
                context.Pickups.Add(viewModel.Pickup);

                //Get User Id keyed to the customer Application User Id
                viewModel.Customer.AppicationUserId = User.Identity.GetUserId();
                //Now Add Customer to database
                context.Customers.Add(viewModel.Customer);
                viewModel.Pickup.CustomerId = viewModel.Customer.Id;

                //Getting Date from Day -- helper method
                viewModel.Pickup.PickupDate = GetDateFromDay(viewModel.Pickup.PickupDay);
               
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
                var pickup = context.Pickups.FirstOrDefault(a => a.CustomerId == id);
                var viewModel = new CustomerAddressViewModel
                {
                    Customer = customer,
                    Pickup = pickup,
                    Day = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" }

                };
                return View(viewModel);
            }
            catch
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult UpdatePickup(CustomerAddressViewModel Model)
        {
            try
            {
                
                var userLoggedIn = User.Identity.GetUserId();
                var customer = context.Customers.Include(a => a.Address).SingleOrDefault(c => c.AppicationUserId == userLoggedIn);
                if (customer == null)
                    return HttpNotFound();
                var pickup = context.Pickups.FirstOrDefault(p => p.CustomerId == customer.Id);
                
                pickup.PickupDay = Model.Pickup.PickupDay;
                pickup.PickupDate = GetDateFromDay(pickup.PickupDay);
                
                
                if(pickup.SecondPickupDate == null && Model.Pickup.SecondPickupDate != null)
                {
                    pickup.SecondPickupDate = Model.Pickup.SecondPickupDate;
                    pickup.SecondPickupDay = pickup.SecondPickupDate.Value.DayOfWeek;
                    Pickup extraPickup = new Pickup();
                    extraPickup.PickupDate = Model.Pickup.SecondPickupDate;
                    extraPickup.PickupDay = extraPickup.PickupDate.Value.DayOfWeek;
                    extraPickup.CustomerId = customer.Id;
                    context.Pickups.Add(extraPickup);
                    customer.ExtraPickupRequest = true;
                }
                context.SaveChanges();
                return RedirectToAction("Index");
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
                var customerFromDb = context.Customers.Include(a => a.Address).SingleOrDefault(c => c.AppicationUserId == userLoggedIn);
                var pickup = context.Pickups.SingleOrDefault(p => p.CustomerId == customerFromDb.Id);
                if (customerFromDb == null)
                {
                    return HttpNotFound();
                }
                var viewModel = new CustomerAddressViewModel
                {
                    Customer = customerFromDb,
                    Pickup = pickup
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

        public DateTime GetDateFromDay(DayOfWeek day)
        {
            DateTime date;
            int num = (int)day;
            int num2 = (int)DateTime.Today.DayOfWeek;
            if(num > num2)
            {
                date = DateTime.Today.AddDays(num - num2);
            }
            else if(num2 > num)
            {
                date = DateTime.Today.AddDays(7-(num2-num));
            }
            else
            {
                date = DateTime.Today.AddDays(7);
            }
            return date;
            
        }
    }
}