using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Account
    {
        public String m_iban;
        public List<SingleDay> m_days;
        public bool m_giveMoney = false;
        public bool m_takeMoney = false;
        public decimal m_sockel = 800m;

        public void LoadDays(int historicalDays,int futureDays)
        {
            m_days=new List<SingleDay> { };

            DateTime loopingDate = DateTime.Now;
            loopingDate=loopingDate.AddDays(-historicalDays);
            DateTime endDate = DateTime.Now;
            endDate= endDate.AddDays(futureDays);
            for (; loopingDate<=endDate; loopingDate=loopingDate.AddDays(1))
            {
                SingleDay day = new SingleDay(this);
                day.Load(loopingDate);
                if (!day.IsEmpty)
                {
                    m_days.Add(day);
                }
                else
                {
                    if(m_days.Count()>0)
                    {
                        SingleDay lastDay = m_days.Last();
                        lastDay.m_date = loopingDate;
                        m_days.Add(lastDay);
                    }
                }
            }

        }
    }
}
