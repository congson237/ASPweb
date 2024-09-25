using System.ComponentModel.DataAnnotations;

namespace BaiTap07.Models
{
    public class TheLoai
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Không được để trống!")]
        [Display(Name="Thể Loại")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Không đúng định dạng ngày tháng năm!")]
        [Display(Name="Thể Loại")]
        public DateTime datacreate { get; set; } = DateTime.Now;
    }
}
