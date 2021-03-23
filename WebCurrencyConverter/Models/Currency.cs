using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCurrencyConverter.Models
{
    public class Currency
    {
        public int id { get; set; }
        public string name { get; set; }

        public decimal amount { get; set; }

        public decimal rate { get; set; }

    }
}