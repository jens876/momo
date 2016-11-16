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
        private bool m_empty = false;
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
            String ret = "";
            List<string> retx = new List<string> { };
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    ret = reader["ba_debtorAccountNumber"].ToString();
                    retx.Add(ret);
                }
            }
        }
    }
}
