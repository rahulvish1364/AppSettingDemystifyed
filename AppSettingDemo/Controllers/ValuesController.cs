using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppSettingDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public ValuesController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {
                this.configuration.GetValue<string>("MyAppSettings"),
                this.configuration.GetValue<string>("NestedSettings:SubSettings1"),
                this.configuration.GetConnectionString("Default"),
                this.configuration.GetConnectionString("MyLocalDB")
            };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return this.configuration.GetValue<string>("MyAppSettings");
        }
    }
}
