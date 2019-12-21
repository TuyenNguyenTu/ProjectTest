using Microsoft.AspNetCore.Http;
using ProjectTest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Areas.Admin.Models
{
    public class PostCreateViewModel
    {

        [Display(Name = "Tiêu đề")]
        [Required(ErrorMessage = "Bạn không được bỏ trống mục này")]
        [Column(TypeName = "nvarchar(500)")]
        public string Title { set; get; }

        [Display(Name = "Nội dung")]
        [Required(ErrorMessage = "Bạn không được bỏ trống mục này")]
        [Column(TypeName = "ntext")]
        public string ContentPost { set; get; }


        [Column(TypeName = "nchar(500)")]
        public string MetaTitle { set; get; }

        [Display(Name = "Ngày viết bài")]
        public DateTime CreatedDate { set; get; }

        [Display(Name = "Người viết")]
        [Required(ErrorMessage = "Bạn không được bỏ trống mục này")]
        [Column(TypeName = "nvarchar(50)")]
        public string CreatedBy { set; get; }

        [Display(Name = "Ngày chỉnh sửa gần nhất")]
        public DateTime? ModifiedDate { set; get; }

        [Display(Name = "Người chỉnh sửa")]
        [Required(ErrorMessage = "Bạn không được bỏ trống mục này")]
        [Column(TypeName = "nvarchar(250)")]
        public string ModifiedBy { set; get; }

        [Column(TypeName = "nvarchar(250)")]
        public string MetaKeyword { set; get; }

        [Display(Name = "Mô tả sơ lược")]
        [Required(ErrorMessage = "Bạn không được bỏ trống mục này")]
        [Column(TypeName = "nvarchar(500)")]
        public string MetaDescription { set; get; }

        [Display(Name = "Lượt xem")]
        public long ViewCount { set; get; }

        [Display(Name = "Trạng thái")]


        public bool Status { set; get; }
        [Display(Name = "Ghi chú hình ảnh")]
        [Column(TypeName = "ntext")]
        public string Note { set; get; }


        [Display(Name = "HinhAnh")]
        [Column(TypeName = "nvarchar(500)")]
        public IFormFile HinhAnh { set; get; }

        [Display(Name = "Loại bài viết")]
        public long CategoryId { set; get; }
        [ForeignKey("CategoryId")]
        public CategoryPost CategoryPost { set; get; }
    }
}
