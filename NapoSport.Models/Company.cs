using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapoSport.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Tên công ty đối tác")]
        public string Name { get; set; }
        [DisplayName("Địa chỉ")]
        public string? Address { get; set; }
        [DisplayName("Trạng thái")]
        public string? State { get; set; }
        [DisplayName("Số điện thoại")]
        public string? PhoneNumber { get; set; }
        [DisplayName("Mã bưu điện")]
        public string? PostalCode { get; set; }
    }
}
