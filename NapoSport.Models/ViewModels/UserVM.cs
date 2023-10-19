using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapoSport.Models.ViewModels
{
    public class UserVM
    {
        public ApplicationUser User { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CompanyList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> RoleList { get; set; }
    }
}
