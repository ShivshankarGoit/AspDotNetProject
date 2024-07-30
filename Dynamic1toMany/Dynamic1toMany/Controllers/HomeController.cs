using Dynamic1toMany.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Dynamic1toMany.Controllers
{
    public class HomeController : Controller
    {
        private readonly OrderDetailEntities _Context = new OrderDetailEntities();
        public ActionResult Index()
        {
            var emp = _Context.Orders.ToList();
            return View(emp);
        }
        // GET: Orders/Create
        public ActionResult Create()
        {
            var model = new OrderViewModel();
            return View(model);
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    OrderName = model.OrderName,
                    OrderItems = model.OrderItems.Select(i => new OrderItem
                    {
                        ProductName = i.ProductName,
                        Qiantity = i.Quantity
                    }).ToList()
                };

                _Context.Orders.Add(order);
                 _Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var order =  _Context.Orders.FirstOrDefault(m => m.OrderId == id);
            if (order == null)
            {
                return HttpNotFound();
            }

            var model = new OrderViewModel
            {
                OrderId = order.OrderId,
                OrderName = order.OrderName,
                OrderItems = order.OrderItems.Select(i => new OrderItemViewModel
                {
                    OrderItemId = i.OrderItemID,
                    ProductName = i.ProductName,
                    Quantity = i.Qiantity
                }).ToList()
            };

            return View(model);
        }



        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrderViewModel model)
        {
            if (id != model.OrderId)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                Order order = _Context.Orders.Find(id);

                if (order == null)
                {
                    return HttpNotFound();
                }

                // Update Order details
                order.OrderName = model.OrderName;

                // Existing OrderItems in the database
                var existingOrderItems = order.OrderItems.ToList();

                // Handling additions and updates
                foreach (var item in model.OrderItems)
                {
                    if (item.OrderItemId > 0) // Existing item, update it
                    {
                        var existingItem = existingOrderItems.FirstOrDefault(oi => oi.OrderItemID == item.OrderItemId);
                        if (existingItem != null)
                        {
                            existingItem.ProductName = item.ProductName;
                            existingItem.Qiantity = item.Quantity;
                        }
                    }
                    else // New item, add it
                    {
                        order.OrderItems.Add(new OrderItem
                        {
                            ProductName = item.ProductName,
                            Qiantity = item.Quantity,
                            OrderId = order.OrderId // Ensure foreign key is set
                        });
                    }
                }

                // Handling deletions
                var modelItemIds = model.OrderItems.Select(i => i.OrderItemId).ToHashSet();
                foreach (var existingItem in existingOrderItems)
                {
                    if (!modelItemIds.Contains(existingItem.OrderItemID))
                    {
                        _Context.OrderItems.Remove(existingItem);
                    }
                }

                try
                {
                    _Context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    // Handle any database update exceptions here
                    // For example, log the error or provide feedback to the user
                    throw;
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Order order = _Context.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }

        // POST: Home/DeleteStudentAndCourses/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
             Order order = _Context.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }

            // Delete all courses associated with the student
            // foreach (var course in student.courses.ToList())
            // {
            //   _context.courses.Remove(course);
            // }
            _Context.OrderItems.RemoveRange(order.OrderItems.ToList());
            // Remove the student itself
            _Context.Orders.Remove(order);

            // Save changes to the database
            _Context.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}
