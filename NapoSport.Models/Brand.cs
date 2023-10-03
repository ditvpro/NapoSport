using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapoSport.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        [Required, DisplayName("Tên thương hiệu")]
        public string? Name { get; set; }
        [DisplayName("Hình ảnh thu nhỏ")]
        public string? LogoUrl { get; set; }
        [Required, DisplayName("Mô tả")]
        public string? Description { get; set; }
        [MaxLength(200), DisplayName("Đường dẫn trang chủ")]
        public string? Website { get; set;}
    }
}
