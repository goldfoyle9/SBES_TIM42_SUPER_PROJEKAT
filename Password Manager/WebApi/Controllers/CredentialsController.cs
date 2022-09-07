using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;

namespace WebApi.Controllers
{
    [Route("api/credentials")]
    [ApiController]
    public class CredentialsController : ControllerBase
    {
        private readonly IConfiguration _config;

        public CredentialsController(IConfiguration config)
        {
            _config = config; 
        }


        [EnableCors]
        [HttpGet("websiteCredentials")]
        //[Authorize]
        public IActionResult GetCredentials(string website)
        {
            var connString = _config.GetConnectionString("connectionString");
            Dictionary<int,string> passwords = DatabaseManager.Get("Passwords", connString);
            List<Credentials> retList = new List<Credentials>();

            foreach (int id in passwords.Keys)
            {
                var cred = Credentials.Deserialize(passwords[id], id, website);
                if (cred != null)
                {
                    retList.Add(cred);

                }
            }

            return Ok(retList);
        }

    }
}
