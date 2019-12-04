using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Models
{
    public class Footer
    {
        [Key]
        [Display(Name ="Mã")]
        public long Id { set; get; }

        [Display(Name ="Nội dung")]
        [Required(ErrorMessage ="Bạn phải nhập trường này")]
        [Column(TypeName ="ntext")]
        public string Contents { set; get; }

        [Display(Name ="Ngày tạo")]
        public DateTime? CreatedDate { set; get; }

        [Display(Name ="Trạng thái")]
        [DefaultValue("true")]
        public bool Status { set; get; }
    }
}
