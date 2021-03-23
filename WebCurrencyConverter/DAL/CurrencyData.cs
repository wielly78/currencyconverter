using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using WebCurrencyConverter.Models;
using WebCurrencyConverter.sharedfunction;

namespace WebCurrencyConverter.DAL
{
    public class CurrencyData
    {
        public List<Currency> GetCurrencyRateList()
        {
            string sqlsource = ConfigurationManager.ConnectionStrings["sqlsource"].ConnectionString;

            List<Currency> list = new List<Currency>();

            SqlConnection conn = new SqlConnection(sqlsource);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from currency";

            SqlDataReader reader = cmd.ExecuteReader();

            decimal rate = 0;

            while (reader.Read())
            {
                Currency cur = new Currency();
                //string names = reader["name"].ToString();
                try
                {
                    cur.name = reader["name"].ToString();
                    cur.rate = Convert.ToDecimal(reader["amount"]);
                }
                catch (Exception ex)
                {

                }

                list.Add(cur);
            }

            conn.Close();

            return list;
        }

        public decimal GetRateCurrency(string name)
        {
            string sqlsource = ConfigurationManager.ConnectionStrings["sqlsource"].ConnectionString;

            Currency cur = new Currency();

            SqlConnection conn = new SqlConnection(sqlsource);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select amount from currency where name=@name";
            cmd.Parameters.AddWithValue("@name", name);

            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            decimal rate = 0;

            try
            {
                while (reader.Read())
                {
                    //string names = reader["name"].ToString();
       
                    rate = Convert.ToDecimal(reader["amount"]);
                }
            }
            catch (Exception ex)
            {
                CommonFunction.WriteToLog("exception in GetRateCurrency: " + ex.Message);
            }
            finally
            {
                try
                {
                    conn.Close();
                }
                catch (Exception) { }
            }

      

            return rate;
        }
    }
}