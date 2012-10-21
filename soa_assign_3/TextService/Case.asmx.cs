/// Case.asmx.cs
/// Thomas Kempton & Samuel Lewis 2012
///

namespace soa_assign_3
{
    using System.Configuration;
    using System.Web.Services;

    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "localhost/TextService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Case : System.Web.Services.WebService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Case" /> class.
        /// </summary>
        public Case()
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
        /// Converts a string's case.
        /// </summary>
        /// <param name="incoming">The incoming.</param>
        /// <param name="flag">The flag.</param>
        /// <returns>
        ///   Upper case if the flag is 1, lower case if the flag is 0.
        /// </returns>
        [WebMethod]
        public string CaseConvert(string incoming, int flag)
        {
            if(string.IsNullOrEmpty(incoming))
            {
                throw this.Factory.Create(
                        Context.Request.Url.AbsoluteUri,
                        "No string provided.",
                        "Parameter incoming cannot be null or empty.");
            }

            if (flag == 1)
            {
                return incoming.ToUpper();
            }
            else if (flag == 2)
            {
                return incoming.ToLower();
            }
            else
            {
                throw this.Factory.Create(
                        Context.Request.Url.AbsoluteUri,
                        "Unknown flag value.",
                        "The flag may only be 1 or 2.");
            }
        }
    }
}