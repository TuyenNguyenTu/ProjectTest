﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Models
{
    public class Slide
    {
        [Key]
        public long Id { get; set; }

        [Display(Name ="Hình ảnh")]
        [Column(TypeName ="nvarchar(250)")]
        public string Image { get; set; }

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
        [DefaultValue("true")]
        public bool Status { set; get; }
    }
}
