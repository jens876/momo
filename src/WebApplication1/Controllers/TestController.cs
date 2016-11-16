﻿using System;
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
                //ConnectionString = "server=localhost;user id=root;password=x;persistsecurityinfo=True;port=3306;Encrypt=false;"
                ConnectionString = "server=172.30.86.135;user id=microcredit;password=M1crocred1t;persistsecurityinfo=True;port=3306;Encrypt=false;"
            };
            connection.Open();

            MySqlCommand command = new MySqlCommand("create database IF NOT EXISTS momo1db;", connection);
            command.ExecuteNonQuery();

            command = new MySqlCommand("use momo1db;", connection);
            command.ExecuteNonQuery();

            command = new MySqlCommand("create table IF NOT EXISTS balances (ba_debtorAccountNumber varchar(22), ba_date date,ba_balance double);", connection);
            command.ExecuteNonQuery();

            command = new MySqlCommand("insert into balances(ba_debtorAccountNumber,ba_date,ba_balance) values (\"DE99999940000317899806\",\"2016-11-16\",12.34);", connection);
            command.ExecuteNonQuery();

            command = new MySqlCommand("select * from balances", connection);

            String ret="";
            List<string> retx = new List<string> { };
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ret = reader["ba_debtorAccountNumber"].ToString();
                    retx.Add(ret);
                }
            }

            connection.Close();
            
            //IEnumerable<string> retx=new List<string>;
            return retx;

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
