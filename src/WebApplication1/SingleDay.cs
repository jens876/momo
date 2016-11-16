using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WebApplication1
{

    public class SingleDay
    {
        public DateTime m_date;
        private bool m_empty = true;
        public bool IsEmpty
        {
            get
            {
                return m_empty;
            }
        }
        public decimal m_realBalance;
        public decimal m_realBalanceChange;
        public decimal m_fictionalBalanceChange;
        Account m_account;

        public SingleDay(Account account)
        {
            m_account = account;
        }

        public void Load(DateTime date)
        {
            m_date = date;

            MySqlCommand command = new MySqlCommand("select * from balances where ba_date=\""+ date.ToString("yyyy-MM-dd")+ "\" and ba_debtorAccountNumber=\""+m_account.m_iban+"\"", StaticProperties.m_mySqlConnection);
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    if(decimal.TryParse(reader["ba_balance"].ToString(), out m_realBalance))
                    {
                        m_realBalance /= 100m;
                        m_realBalance -= 600m;
                        m_empty = false;
                        if(m_account.m_takeMoney)
                        {
                            if(m_realBalance<0m)
                            {
                                m_fictionalBalanceChange = -m_realBalance;
                            }
                        }
                        if(m_account.m_giveMoney)
                        {
                            if (m_realBalance > m_account.m_sockel)
                            {
                                m_fictionalBalanceChange = -(m_realBalance- m_account.m_sockel);
                            }
                        }
                    }
                }
            }
        }
    }
}
