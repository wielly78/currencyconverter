using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebCurrencyConverter.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetExchangeRate()
        {
            Currency cur = new Currency();
            cur.id = 1;
            cur.name = "usd";
            ExchangeCurrency exc = new ExchangeCurrency();
            decimal rate = exc.getExchangeRate(cur);

            Assert.AreEqual(1.3574, rate);
        }
    }
}
