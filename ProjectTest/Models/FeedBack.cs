using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Models
{
    public class FeedBack
    {
        [Key]
        [Display(Name = "Mã phản hồi")]
        public long Id { set; get; }

        [Column(TypeName ="nvarchar(100)")]
        [Display(Name="Tên người phản hồi")]
        [Required(ErrorMessage ="Bạn phải nhập cái này")]
        public string Name { set; get; }

        [Column(TypeName = "varchar(12)")]
        [Display(Name = "Số điện thoại")]
        public string Phone { set; get; }

        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Bạn phải nhập trường này")]
        [RegularExpression(@"^[a-z][a-z0-9_\.]{5,32}@[a-z0-9]{2,}(\.[a-z0-9]{2,4}){1,2}$")]
        public string Email { set; get; }

        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Bạn phải nhập trường này")]
        public string Address { set; get; }

        [Column(TypeName = "nvarchar(500)")]
        [Display(Name = "Nội dung phản hồi")]
        [Required(ErrorMessage = "Bạn phải nhập trường này")]
        public string Contents { set; get; }

        [Display(Name = "Ngày phản hồi")]
        public DateTime CreatedDate { set; get; }

        [Display(Name = "Trạng thái")]
        [DefaultValue("true")]
        public bool Status { set; get; }
        
    }
}
