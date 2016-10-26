using LVSA.Base.Application.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LVSA.Base.Presentation.ViewModels
{
    public class ProfileViewModel
    {
        public HttpPostedFileBase File { get; set; }
        public string OldPassword { get; set; }
        [Comprimento(10, 2)]
        public string NewPassword { get; set; }
        [Comprimento(10, 2)]
        public string ConfirmPassword { get; set; }
    }
}