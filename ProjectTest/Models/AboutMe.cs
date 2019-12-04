using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Models
{
    public class AboutMe
    {
        [Key]
        public long Id { set; get; }

        [Display(Name ="Họ")]
        [Required(ErrorMessage = "Bạn chưa nhập Tên")]
        [Column(TypeName ="nvarchar(50)")]
        public string FirstName { set; get; }

        [Display(Name ="Tên")]
        [Column(TypeName ="nvarchar(50)")]
        [Required(ErrorMessage ="Bạn chưa nhập Tên")]
        public string LastName { set; get; }

        [Display(Name = "Tiêu đề")]
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Bạn chưa nhập tên tiêu đề")]
        public string Title { set; get; }

        [Column(TypeName = "nvarchar(250)")]
        public string MetaTitle { set; get; }

        [Display(Name = "Giới thiệu")]
        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Bạn chưa nhập Tên")]
        public string Introduce { set; get; }

        [Display(Name = "Ảnh")]
        [Column(TypeName = "nvarchar(500)")]
        public string Image { set; get; }

        [Display(Name = "Ngày viết bài")]
        public DateTime CreatedDate { set; get; }

        [Display(Name = "Người viết bài")]
        [Column(TypeName = "nvarchar(50)")]
        public string CreatedBy { set; get; }

        [Display(Name = "Ngày sửa gần nhất")]
        public DateTime? ModifiedDate { set; get; }

        [Display(Name = "Trạng thái")]
        [Required]
        public bool Status { set; get; }

        [Display(Name = "Ghi chú")]
        [Column(TypeName = "ntext")]
        public string Note { set; get; }

    }
}
