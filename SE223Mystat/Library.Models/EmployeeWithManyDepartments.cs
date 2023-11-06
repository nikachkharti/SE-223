using Library.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Library.Models
{
    public class EmployeeWithManyDepartments
    {
        public Employee? Employee { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? Departments { get; set; }
    }
}
