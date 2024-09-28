using Microsoft.AspNetCore.Mvc;

namespace BaiKiemTra02.Controllers
{
	using BaiKiemTra02.Data;
	using BaiKiemTra02.Models;
	using Microsoft.AspNetCore.Mvc;
	using System.Linq;

	public class LopHocController : Controller
	{
		private readonly ApplicationDbContext _db;

		public LopHocController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
            var lophoc = _db.LopHocs.ToList();
            ViewBag.lophoc = lophoc;
            return View();
        }

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(LopHoc lopHoc)
		{
			if (ModelState.IsValid)
			{
				_db.LopHocs.Add(lopHoc);
				_db.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(lopHoc);
		}

		public IActionResult Edit(int id)
		{
			var lopHoc = _db.LopHocs.Find(id);
			if (lopHoc == null) return NotFound();
			return View(lopHoc);
		}

		[HttpPost]
		public IActionResult Edit(LopHoc lopHoc)
		{
			if (ModelState.IsValid)
			{
				_db.Update(lopHoc);
				_db.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(lopHoc);
		}

		public IActionResult Delete(int id)
		{
			var lopHoc = _db.LopHocs.Find(id);
			if (lopHoc == null) return NotFound();
			return View(lopHoc);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int id)
		{
			var lopHoc = _db.LopHocs.Find(id);
			_db.LopHocs.Remove(lopHoc);
			_db.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Details(int id)
		{
			var lopHoc = _db.LopHocs.Find(id);
			if (lopHoc == null) return NotFound();
			return View(lopHoc);
		}
	}
}