using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Areas.Admin.Models
{
    public class SlideCreateViewModel
    {
        [Display(Name = "Hình ảnh")]
        [Column(TypeName = "nvarchar(250)")]
        public IFormFile Image { get; set; }

        [Display(Name = "Thứ tự")]
        [Required]
        public int DisplayOrder { set; get; }

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Link { set; get; }

        [Display(Name = "Mô tả")]
        [Column(TypeName = "nvarchar(250)")]
        public string Description { set; get; }

        [Display(Name = "Ngày tạo")]

        public DateTime CreatedDate { set; get; }

        [Display(Name = "Người tạo")]
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string CreatedBy { set; get; }

        [Display(Name = "Ngày chỉnh sửa gần nhất")]
        public DateTime? ModifiedDate { set; get; }

        [Display(Name = "Hiển thị")]
        public bool Status { set; get; }
    }
}
