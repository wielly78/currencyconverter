using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCurrencyConverter.DAL;

namespace WebCurrencyConverter.Models
{
    public class ExchangeCurrency
    {
        //private Currency currency;

        public decimal getExchangedAmount(Currency targetCurrency)
        {
            CurrencyData curdat = new CurrencyData();

            if (targetCurrency.name.ToLower() == "usd")
            {
                return targetCurrency.amount / curdat.GetRateCurrency("usd");
            }
            else if(targetCurrency.name.ToLower() == "hkd")
            {
                return targetCurrency.amount / curdat.GetRateCurrency("hkd");
            }
            else
            {
                List<Currency> list = curdat.GetCurrencyRateList();
                decimal rate = 0;

                foreach (Currency currency in list)
                {
                    if (targetCurrency.name == currency.name)
                    {
                        rate = curdat.GetRateCurrency(currency.name);
                        break;
                    }
                }

                if (rate > 0)
                    return targetCurrency.amount / rate;
                else
                    return 0;
            }
        }


        public decimal getExchangeRecommenedAmount(Currency targetCurrency)
        {
            CurrencyData curdat = new CurrencyData();

            decimal res = 0;

            if (targetCurrency.name == "usd")
            {
                res = targetCurrency.amount / curdat.GetRateCurrency("usd");


                if((int) res % 100 != 0)
                {

                }
            }
            else
            {
                res = targetCurrency.amount / curdat.GetRateCurrency("hkd");
            }

            return res;
        }

        
        public decimal getExchangeRate(Currency targetCurrency)
        {
            CurrencyData curdat = new CurrencyData();

            if (targetCurrency.name == "usd")
            {
                return curdat.GetRateCurrency("usd");
            }
            else if(targetCurrency.name == "hkd")
            {
                return curdat.GetRateCurrency("hkd");
            }
            else
            {
                List<Currency> list = curdat.GetCurrencyRateList();
                decimal rate = 0;

                foreach (Currency currency in list)
                {
                    if (targetCurrency.name == currency.name)
                    {
                        rate = curdat.GetRateCurrency(currency.name);
                        break;
                    }
                }

                return rate;
            }
        }


    }
}