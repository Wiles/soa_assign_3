/// Stocks.asmx.cs
/// Thomas Kempton & Samuel Lewis 2012
///

namespace soa_assign_3
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Services;

    /// <summary>
    /// Summary description for TickerTape
    /// </summary>
    [WebService(Namespace = "localhost/TickerTape")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Stocks : System.Web.Services.WebService
    {
        public struct QuoteInfo
        {
            public string Symbol;
            public double LastPrice;
            public string LastPriceDate;
            public string LastPriceTime;

        }

        [WebMethod]
        public QuoteInfo GetQuote(string tickerSymbol)
        {
            QuoteInfo i = new QuoteInfo();

            i.Symbol = tickerSymbol;
            return i;
        }
    }
}
