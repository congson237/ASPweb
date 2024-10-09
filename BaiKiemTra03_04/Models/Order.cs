using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra03_04.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Ngày đặt hàng không được để trống")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Tổng số tiền không được để trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Tổng số tiền phải là một số dương.")]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Mã nhà cung cấp không được để trống")]
        public int SupplierID { get; set; }

        public string OrderStatus { get; set; }  

        public virtual Supplier Supplier { get; set; }
    }
}
