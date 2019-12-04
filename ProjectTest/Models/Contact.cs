using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Models
{
    public class Contact
    {
        [Key]
        public long Id { set; get; }

        [Display(Name ="Nội dung")]
        [Required(ErrorMessage ="Không được bỏ trống")]
        [Column(TypeName ="ntext")]
        public string Contents { set; get; }

        [Display(Name ="Trạng thái")]
        [DefaultValue("true")]
        public bool Status { set; get; }
    }
}
