using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapoSport.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required, DisplayName("Tên sản phẩm")]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Required, DisplayName("Mã sản phẩm")]
        public int? Code { get; set; }
        [Required, DisplayName("Giá thị trường")]
        public double MarketPrice { get; set; }
        [Required, DisplayName("Giá bán")]
        public double Price { get; set; }
        [DisplayName("Giảm giá")]
        [Range(0, 100, ErrorMessage = "Giá trị phải từ 0 đến 100")]
        public int? Discount { get; set; }
        [MaxLength(200), DisplayName("Ưu đãi")]
        public string? Offers { get; set; }
        [Required, DisplayName("Thông tin sản phẩm")]
        public string? ProductInfo { get; set; }
        [Required, DisplayName("Hướng dẫn sử dụng")]
        public string? RecommendedUsage { get; set; }
        [ValidateNever]
        public string? ImageUrl {  get; set; }
        [ValidateNever]
        public int CategoryId { get; set; }
        [ValidateNever]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        [ValidateNever]
        public int BrandId { get; set; }
        [ValidateNever]
        [ForeignKey(nameof(BrandId))]
        public Brand Brand { get; set; }

    }
}
