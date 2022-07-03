using ExpedienteMedico.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExpedienteMedico.Models.ViewModels
{
    public class PhysicianVM
    {

        public Physician Physician { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> SpecialtyList { get; set; }


    }
}
