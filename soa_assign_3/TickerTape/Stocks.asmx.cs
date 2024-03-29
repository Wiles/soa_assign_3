﻿/// Stocks.asmx.cs
/// Thomas Kempton & Samuel Lewis 2012
///

namespace soa_assign_3
{
    using System.Configuration;
    using System.Web.Services;
    using System.Xml;

    /// <summary>
    /// Service class for providing stock information.
    /// </summary>
    [WebService(Namespace = "localhost/TickerTape")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Stocks : System.Web.Services.WebService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Stocks" /> class.
        /// </summary>
        public Stocks()
        {
            this.Factory = new ExceptionFactory(
                ConfigurationManager.AppSettings["logPath"]);
        }

        /// <summary>
        /// Gets or sets the factory.
        /// </summary>
        /// <value>
        /// The factory.
        /// </value>
        private ExceptionFactory Factory { get; set; }

        /// <summary>
        /// Represents a stock quote record.
        /// </summary>
        public struct QuoteInfo
        {
            public string Symbol;
            public double LastPrice;
            public string LastPriceDate;
            public string LastPriceTime;
        }

        /// <summary>
        /// Gets the stock quote.
        /// </summary>
        /// <param name="tickerSymbol">The ticker symbol.</param>
        /// <returns>The stock quote information.</returns>
        [WebMethod]
        public QuoteInfo GetQuote(string tickerSymbol)
        {
            if (string.IsNullOrEmpty(tickerSymbol))
            {
                throw this.Factory.Create(
                        Context.Request.Url,
                        "No string provided.",
                        "Parameter tickerSymbol cannot be null or empty.");
            }

            try
            {
                var svc = new StockQuote.StockQuote();
                var response = svc.GetQuote(tickerSymbol);

                if (response == "exception")
                {
                    throw this.Factory.Create(
                            Context.Request.Url,
                            "Invalid ticker symbol provided.",
                            "The provided ticker symbol could not be found.");
                }

                var doc = new XmlDocument();
                doc.LoadXml(response);
                var stock = doc.FirstChild.FirstChild;

                var i = new QuoteInfo();
                i.Symbol = stock["Symbol"].InnerText;
                i.LastPrice = double.Parse(stock["Last"].InnerText);
                i.LastPriceDate = stock["Date"].InnerText;
                i.LastPriceTime = stock["Time"].InnerText;

                return i;
            }
            catch
            {
                throw this.Factory.Create(
                        Context.Request.Url,
                        "Internal Exception.",
                        "A fatal exception occured while retrieving the results.");
            }
        }
    }
}
