using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectPorfolioSystem.Utils.Interface
{
    public interface IUtils
    {
        object GenerateJwtToken(string email, IdentityUser user, string imagePath, string role, string address, string phonenumber);
        string CreateCode();
    }
}
