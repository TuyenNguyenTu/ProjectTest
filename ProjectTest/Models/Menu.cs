using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTest.Models
{
    public class Menu
    {
        [Key]
        public long Id { set; get; }

        [Display(Name ="Tên hiển thị")]
        [Required(ErrorMessage ="Bạn phải nhập trường này")]
        [Column(TypeName ="nvarchar(50)")]
        public string Text { set; get; }


        [Column(TypeName = "nvarchar(250)")]
        public string Link { set; get; }

        [Display(Name = "Thứ tự hiển thị")]
        [Required(ErrorMessage = "Bạn phải nhập trường này")]
        public string DisplayOrder { set; get; }


        [Display(Name = "Hiển thị")]
        [Required(ErrorMessage = "Bạn phải nhập trường này")]
        public bool Status { set; get; }

        [Display(Name = "Loại Menu")]
        [Required(ErrorMessage = "Không để trống trường này")]
        public long TypeID { set; get; }
        [ForeignKey("TypeID")]
        public TypeMenu TypeMenu { set; get; }

    }
}
