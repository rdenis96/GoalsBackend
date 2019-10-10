using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MainServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IHostingEnvironment _environment;

        public InfoController(IHostingEnvironment env)
        {
            _environment = env;
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            var ip = this.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ip))
            {
                ip = this.Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }
            var resultJson = JsonConvert.SerializeObject(new
            {
                host = Environment.MachineName,
                environment = _environment.EnvironmentName,
                //machine_hostname = EnvironmentHelper.MachineHostname,
                //version = Assembly.GetAssembly(typeof(LicenseInfo)).GetName().Version.ToString(),
                publicIp = ip
            });

            return resultJson;
        }
    }
}