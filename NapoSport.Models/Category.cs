using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapoSport.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Tên danh mục")]
        public string? Name { get; set; }
        [DisplayName("Thứ tự hiển thị")]
        [Required, Range(1, 100, ErrorMessage = "Giá trị phải từ 1 đến 100!")]
        public int? DisplayOrder { get; set; }
        [DisplayName("Hình ảnh thu nhỏ")]
        public string? Thumbnail {  get; set; }
    }
}
