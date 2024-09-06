using Microsoft.AspNetCore.Mvc;

namespace BaiTapvenha02.Controllers
{
    public class Tuan02Controller : Controller
    {
        public IActionResult Index()
        {
            ViewBag.HoTen = "Nguyễn Trần Công Sơn";
            ViewBag.MSSV = "1822041718";
            ViewBag.Nam = " 2024 ";
            return View();
        }
        public ActionResult MayTinh(int a, int b, string pheptinh)
        {
            double ketqua = 0;


            switch (pheptinh)
            {
                case "cong":
                    ketqua = a + b;
                    break;
                case "tru":
                    ketqua = a - b;
                    break;
                case "nhan":
                    ketqua = a * b;
                    break;
                case "chia":

                    if (b != 0)
                    {
                        ketqua = (double)a / b;
                    }
                    else
                    {
                        ViewBag.ThongBao = "Không thể chia cho 0";
                    }
                    break;
                default:
                    ViewBag.ThongBao = "Phép tính không hợp lệ";
                    break;
            }


            if (ViewBag.ThongBao == null)
            {
                ViewBag.KetQua = ketqua;
            }

            return View();
        }
    }
}
