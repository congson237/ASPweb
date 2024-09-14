using BaiTapKiemTra01.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTapKiemTra01.Controllers
{
    public class TaiKhoanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DangKy(TaiKhoanViewModel model)
        {
            if (model.TenTaiKhoan != null)
            {
               
                string thongTin = $"Tên đăng nhập:{model.TenTaiKhoan}" + " "+
                                  $"Mật khẩu:{model.MatKhau}" + "  " +
                                  $"Họ tên:{model.HoTen}" + "  " +
                                  $"Tuổi:{model.Tuoi}";

            
                return Content(thongTin);
            }

            return View();
        }
    }
}
