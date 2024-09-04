using BaiTap05.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap05.Controllers
{
    public class TheLoaiController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Ngay = "Ngày 28";
            ViewBag.Thang = "Tháng 2";
            ViewData["Nam"] = "Năm 2030";
            return View();
        }
        public IActionResult Index2()
        {
            var TheLoai = new TheLoaiViewModel
            {
                Id = 1,
                Name = "Trinh Thám"
            };
            return View(TheLoai);
        }
    }
}
