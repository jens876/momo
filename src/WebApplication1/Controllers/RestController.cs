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
        [HttpGet("{id}")] //possible values: 'give', 'take', 'givetake' and 'plain'
        public JsonResult Get(string id)
        {
			ChartData x = new ChartData();


            Account account = new Account();
            account.m_iban = "DE00999940000667334953"; // prod
            account.m_iban = "DE99999940000317899806";
            if (id.Equals("givetake"))
            {
                account.m_giveMoney = true;
                account.m_takeMoney = true;
            }
            else if (id.Equals("give"))
            {
                account.m_giveMoney = true;
                account.m_takeMoney = false;
            }
            else if (id.Equals("take"))
            {
                account.m_giveMoney = false;
                account.m_takeMoney = true;
            }
            account.LoadDays(40, 20);
            for (int i = 0; i < account.m_days.Count; i++)
            {
                SingleDay day = account.m_days[i];
                x.accountBalances.Add((double)day.m_realBalance);
                if (account.m_giveMoney|| account.m_takeMoney)
                {
                    x.momoBalances.Add((double)(day.m_realBalance+day.m_fictionalBalanceChange));
                }
                x.balanceLabels.Add(day.m_date.ToString("dd."));
            }

            
			return Json(x);
		}

		// GET api/values/give/5000
		[HttpGet("{id}/{sockelbetrag}")] //possible values: 'give', 'take', 'givetake' and 'plain'
		public JsonResult Get(string id, int sockelbetrag)
		{
			ChartData x = new ChartData();


			Account account = new Account();
			account.m_iban = "DE00999940000667334953";// "DE99999940000317899806";
			if (id.Equals("givetake"))
			{
				account.m_giveMoney = true;
				account.m_takeMoney = true;
			}
			else if (id.Equals("give"))
			{
				account.m_giveMoney = true;
				account.m_takeMoney = false;
			}
			else if (id.Equals("take"))
			{
				account.m_giveMoney = false;
				account.m_takeMoney = true;
			}
			account.LoadDays(20, 20);
			for (int i = 0; i < account.m_days.Count; i++)
			{
				SingleDay day = account.m_days[i];
				x.accountBalances.Add((double)day.m_realBalance);
				if (account.m_giveMoney || account.m_takeMoney)
				{
					x.momoBalances.Add((double)(day.m_realBalance + day.m_fictionalBalanceChange));
				}
				x.balanceLabels.Add(day.m_date.ToString("dd."));
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
