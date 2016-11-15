using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/tc")]
    public class TestController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            MySqlConnection connection = new MySqlConnection
            {
                ConnectionString = "server=localhost;user id=root;password=x;persistsecurityinfo=True;port=3306;Encrypt=false;"
                //                ConnectionString = "server=localhost;user id=<User>;password=<Password>;persistsecurityinfo=True;port=<Port>;database=sakila"
            };
            connection.Open();

            MySqlCommand command = new MySqlCommand("create database IF NOT EXISTS db1;", connection);
            command.ExecuteNonQuery();

            command = new MySqlCommand("use db1;", connection);
            command.ExecuteNonQuery();

            command = new MySqlCommand("create table IF NOT EXISTS customers (cu_id integer AUTO_INCREMENT,cu_name VARCHAR(255) NOT NULL,PRIMARY KEY(cu_id));", connection);
            command.ExecuteNonQuery();

            connection.Close();
            

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
