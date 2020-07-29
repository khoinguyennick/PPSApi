using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjectPorfolioSystem.Utils.Interface;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ProjectPorfolioSystem.Utils.Implementations
{
    public class Utils : IUtils
    {
        private readonly IConfiguration _configuration;
        private readonly int CODE_MAX_LENGTH = 5;

        public Utils(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public object GenerateJwtToken(string email, IdentityUser user, string imagePath, string role, string address, string phonenumber)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.UserData, imagePath),
                new Claim(ClaimTypes.MobilePhone, phonenumber),
                new Claim(ClaimTypes.StreetAddress, address),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public string CreateCode()
        {
            Random rd = new Random();
            string result = "";
            for (int i = 0; i < CODE_MAX_LENGTH; i++)
            {
                result += Convert.ToString((char)rd.Next(65, 90));
            }
            return result;
        }
        public class FileUploadOperation : IOperationFilter
        {
            public void Apply(Operation operation, OperationFilterContext context)
            {
                var result = operation.OperationId;
                if (operation.OperationId.ToLower() == "apiaccountimageput")
                {
                    operation.Parameters.Clear();
                    operation.Parameters.Add(new NonBodyParameter
                    {
                        Name = "pictures",
                        In = "formData",
                        Description = "Upload File",
                        Required = true,
                        Type = "file"
                    });
                    operation.Consumes.Add("multipart/form-data");
                }
            }

        }
    }
}
