using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Models
{
    public class CategoryPost
    {
        [Key]
        [Display(Name ="Mã Loại")]
        public long Id { set; get; }

        [Required(ErrorMessage = "Bạn phải nhập trường này")]
        [Display(Name ="Tên loại")]
        [Column(TypeName = "nvarchar(50)")]
        public string CategoryName { set; get; }

        [Column(TypeName = "nvarchar(50)")]
        public string MetaTitle { set; get; }
        public string MetaKeyword { set; get; }
        public string MetaDescription { set; get; }
        public DateTime? CreatedDate { set; get; }
        public DateTime? ModifiedDate { set; get; }
        [Display(Name = "Hiển thị")]
        public bool Status { set; get; }

        public ICollection<Post> Posts { set; get; }
    }
}
