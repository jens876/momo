using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/data")]
    public class RestController : Controller
    {
        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {
			ChartData x = new ChartData();
			return Json(x);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(string id)
        {
			ChartData x = new ChartData();
			double[] accountBalances = {2000, 1800, 1800, 1750, 1500, 1271.5, 1269.9,
							703.99, 253.5, 130, 120, 100, 80, 30, -55.55,
							-150, -180, -250, -300, -355, -360, -370, -370,
							-370, -370, -800, -955, -1053, -1199, -1530};
			String[] balanceLabels = { "01.", "02.", "03.", "04.", "05.", "06.", "07.", "08.",
				"09.", "10.", "11.", "12.", "13.", "14.", "15.", "16.",
				"17.", "18.", "19.", "20.", "21.", "22.", "23.", "24.",
				"25.", "26.", "27.", "28.", "29.", "30."};
			x.accountBalances.AddRange(accountBalances);
			x.balanceLabels.AddRange(balanceLabels);
			if (id.Equals("withoutmomo"))
			{

			}
			else if (id.Equals("withmomo"))
			{
				double[] momoBalances = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
							0, 0, -50, -30, 0, 0, 0, 0, 0, -200, 0, 0, 0,
							0, 0};
				x.momoBalances.AddRange(momoBalances);
			}
			return Json(x);
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
