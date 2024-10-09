using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03_04.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Tên nhà cung cấp không được để trống")]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = "địa chỉ không được để trống")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Số điện thoại phải có 10 chữ số.")]
        public string PhoneNumber { get; set; }
    }
}
