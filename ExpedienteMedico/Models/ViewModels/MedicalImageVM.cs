using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;

namespace ExpedienteMedico.Models.ViewModels
{
    public class MedicalImageVM
    {
        [ValidateNever]
        public string HistoryId { get; set; }

        [ValidateNever]
        public MedicalImage Image { get; set; }

    }
}
