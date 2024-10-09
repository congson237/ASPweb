using BaiKiemTra03_04.Data;
using BaiKiemTra03_04.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaiKiemTra03_04.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Order> order = _db.Order.Include("Supplier").ToList();
            return View(order);
        }

        public IActionResult Create()
        {
            var supplier = _db.Supplier.ToList();
            ViewBag.Supplier = supplier;
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _db.Order.Add(order);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Supplier = _db.Supplier.ToList();
            return View(order);
        }

        // GET: Orders/Edit/5
        public IActionResult Edit(int id)
        {
            var order = _db.Order.Include(o => o.Supplier).FirstOrDefault(o => o.OrderId == id);
            if (order == null) return NotFound();

            ViewBag.Supplier = _db.Supplier.ToList();
            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Order order)
        {
            if (id != order.OrderId) return NotFound();

            if (ModelState.IsValid)
            {
                _db.Update(order);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Suppliers = _db.Supplier.ToList();
            return View(order);
        }

   
        public IActionResult Delete(int id)
        {
            var order = _db.Order.Include(o => o.Supplier).FirstOrDefault(o => o.OrderId == id);
            if (order == null) return NotFound();
            return View(order);
        }

  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _db.Order.Find(id);
            if (order != null)
            {
                _db.Order.Remove(order);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));