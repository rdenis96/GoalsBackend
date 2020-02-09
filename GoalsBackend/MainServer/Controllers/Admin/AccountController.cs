using DataLayer.Context;
using Domain.Account;
using MainServer.Models.Account;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MainServer.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public ActionResult<AccountView> Register([FromBody]AccountView registerModel)
        {
            using (MSSqlContext context = new MSSqlContext())
            {
                Account account = new Account
                {
                    Email = registerModel.Email,
                    Username = registerModel.Username,
                    CreatedDate = DateTime.UtcNow,
                    LastLoginDate = DateTime.MinValue,
                    Ip = "127.0.0.1"
                };

                var passwordHash = ComputeSha256Hash(registerModel.Password);
                account.PasswordHash = passwordHash;
                context.Accounts.Add(account);
                context.SaveChanges();

                return Ok();
            }
        }

        private string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}