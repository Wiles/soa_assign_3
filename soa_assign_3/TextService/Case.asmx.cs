/// Case.asmx.cs
/// Thomas Kempton & Samuel Lewis 2012
///

namespace soa_assign_3
{
    using System.Web.Services;
    using System.Web.Services.Protocols;
    using System.Xml;

    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "localhost/TextService")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Case : System.Web.Services.WebService
    {
        [WebMethod]
        public string CaseConvert(string incoming, int flag)
        {
            if(string.IsNullOrEmpty(incoming))
            {
                //TODO make real soap fault
                Logger.LogError("C:\\temp\\log.txt", "TextService.Case", "No String Provided.");
                throw new SoapException("No string provided",
                            SoapException.ServerFaultCode,
                            Context.Request.Url.AbsoluteUri,
                            null,
                            null);
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
                //TODO make real soap fault
                throw new SoapException("Unknown flag value",
                            SoapException.ServerFaultCode,
                            Context.Request.Url.AbsoluteUri, null, null);
            }
        }
    }
}