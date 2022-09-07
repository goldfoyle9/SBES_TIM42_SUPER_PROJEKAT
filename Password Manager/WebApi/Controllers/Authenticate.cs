using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/authenticate")]
    [ApiController]
    public class Authenticate : ControllerBase
    {
        private string _secretKey = "";
        [EnableCors]
        [HttpGet("auth")]
        public IActionResult AuthenticateExtension(string pinCode)
        {
            using (StreamReader sr = new StreamReader($"{Environment.GetEnvironmentVariable("keydrive", EnvironmentVariableTarget.User)}:\\pin"))
            {
                if (pinCode.ToString() == sr.ReadToEnd().Trim())
                {
                    SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sLvUmBNkkIa8w2ol6D2RstvTLdlTkCZo"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(
                        issuer: "http://localhost:44398",
                        expires: DateTime.Now.AddMinutes(20),
                        signingCredentials: signinCredentials
                    );
                    string tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return Ok(new TokenModel { Token = tokenString }); 
                }
            }
            return Ok(null);
        }
    }
}
