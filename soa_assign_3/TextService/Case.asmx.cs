using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace soa_assign_3
{
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
                throw new SoapException("No string provided",
                            SoapException.ServerFaultCode,
                            Context.Request.Url.AbsoluteUri, null, null);
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