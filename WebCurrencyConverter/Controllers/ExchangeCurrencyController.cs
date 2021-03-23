using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebCurrencyConverter.Models;

namespace WebCurrencyConverter.Controllers
{
    public class ExchangeCurrencyController : ApiController
    {
        // GET: ExchangeCurrency
        [HttpPost]
        public decimal GetExchangeRate(Currency curr)
        {
            ExchangeCurrency exc = new ExchangeCurrency();

            return exc.getExchangeRate(curr);
        }


        [HttpPost()]
        [Route("GetExchangeAmount")]
        // GET: ExchangeCurrency
        public decimal GetExchangeAmount(Currency curr)
        {
            ExchangeCurrency exc = new ExchangeCurrency();

            decimal amount = 0;

            if(exc.getExchangeRate(curr) == 0)
            {

            }
            else
            {
                amount = (int)exc.getExchangedAmount(curr);
            }

            return amount;

        }


        [HttpPost]
        [Route("GetRecommendationExchange")]
        public string GetRecommendationExchange(Currency curr)
        {
            string res = "";

            ExchangeCurrency exc = new ExchangeCurrency();
            decimal dec = exc.getExchangedAmount(curr);

            // get the nearest hundreds
            int decint = (int)dec;

            int rounded = ((decint + 99) / 100) * 100;

            decimal rate = exc.getExchangeRate(curr);

            decimal res1 = rounded * rate;

            res = "recommeded to get " + curr.name.ToUpper() + rounded + " by exchanging: SGD" + (int)res1;

            return res;
        }

    }
}