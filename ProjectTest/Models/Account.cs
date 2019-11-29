using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectTest.Models
{
    public class Account 
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage ="Bạn phải nhập trường này")]
        [Display(Name ="Tài khoản")]
        [Column(TypeName ="nvarchar(50)")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập trường này")]
        [Display(Name = "Mật khẩu")]
        [Column(TypeName = "varchar(50)")]
        public string PassWord { get; set; }

        [Display(Name ="Ảnh đại diện")]
        [Column(TypeName = "nvarchar(500)")]
        public string Avartar { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập trường này")]
        [Display(Name = "Tên hiển thị")]
        [Column(TypeName = "nvarchar(50)")]
        public string DisplayName { set; get; }

        [Required(ErrorMessage = "Bạn phải nhập trường này")]
        [Display(Name = "Địa chỉ")]
        [Column(TypeName = "nvarchar(50)")]
        public string Address { set; get; }

        [Required(ErrorMessage = "Bạn phải nhập trường này")]
        [Display(Name = "Email")]
        [Column(TypeName = "nvarchar(50)")]
        public string Email { set; get; }

        [Display(Name = "Số điện thoại")]
        [Column(TypeName = "nvarchar(50)")]
        public string Phone { set; get; }

        [Display(Name = "Người lập")]
        public string CreatedBy { set; get; }

        [Display(Name = "Ngày lập")]
        public DateTime? CreatedDate { get; set; }

        [Display(Name = "Ngày sửa cuối")]
        public DateTime? ModifiedDate { set; get; }

        [Display(Name = "Admin")]
        public bool IsAdmin { set; get; }

        [Display(Name = "Trạng thái")]
        [DefaultValue("true")]
        public bool Status { set; get; }
    }
}
