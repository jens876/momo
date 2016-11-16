using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class Account
    {
        public String m_iban;
        List<SingleDay> m_days;

        public void LoadDays(int historicalDays,int futureDays)
        {
            m_days.Clear();
            LoadHistoricalDays(historicalDays);
            
        }

        void LoadHistoricalDays(int days)
        {
            DateTime date=DateTime.Now;
            for (int i = 0; i < days; i++)
            {
                SingleDay day = new SingleDay(this);
                day.Load(date);
                if(!day.IsEmpty)
                {
                    m_days.Add(day);
                }
            }

        }
    }
}
