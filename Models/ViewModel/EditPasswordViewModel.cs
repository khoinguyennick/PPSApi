using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPorfolioSystem.Models.ViewModel
{
    public class EditPasswordViewModel
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
