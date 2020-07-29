using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPorfolioSystem.Models.ViewModel
{
    public class LoginSuccessViewModel
    {
        public string FullName { get; set; }
        public object Token { get; set; }
        public string ImagePath { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

    }
}
