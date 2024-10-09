using BaiKiemTra03_04.Data;
using BaiKiemTra03_04.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiKiemTra03_04.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SupplierController(ApplicationDbContext db)
        {
            _db = db;
        }

 
        public IActionResult Index()
        {
            var supplier = _db.Supplier.ToList();
            return View(supplier);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _db.Supplier.Add(supplier);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

   
        public IActionResult Edit(int id)
        {
            var supplier = _db.Supplier.Find(id);
            if (supplier == null) return NotFound();
            return View(supplier);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Supplier supplier)
        {
            if (id != supplier.SupplierId) return NotFound();

            if (ModelState.IsValid)
            {
                _db.Update(supplier);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        public IActionResult Delete(int id)
        {
            var supplier = _db.Supplier.Find(id);
            if (supplier == null) return NotFound();
            return View(supplier);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var supplier = _db.Supplier.Find(id);
            if (supplier != null)
            {
                _db.Supplier.Remove(supplier);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}