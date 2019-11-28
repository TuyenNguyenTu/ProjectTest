using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Models
{
    public class TypeMenu
    {
        [Key]
        [Display(Name="Mã kiểu menu")]
        public long Id { set; get; }

        [Required(ErrorMessage ="Bạn phải nhập trường này")]
        [Column(TypeName ="nvarchar(50)")]
        [Display(Name= "Tên loại")]
        public string Name { set; get; }
        public ICollection<Menu> Menus { set; get; }
    }
}
