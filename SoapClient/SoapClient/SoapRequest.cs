/// SoapRequest.cs
/// Thomas Kempton 2012
///

namespace SoapClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;

    /// <summary>
    ///  Class for sending soap requests.
    /// </summary>
    public class SoapRequest
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="SoapRequest" /> class.
        /// </summary>
        /// <param name="serviceUrl">The service URL.</param>
        /// <param name="namespaceUrl">The namespace URL.</param>
        /// <param name="method">The method.</param>
        public SoapRequest(Uri serviceUrl, string namespaceUrl, string method)
        {
            var fullMethod = namespaceUrl;
            if (!namespaceUrl.EndsWith("/"))
            {
                fullMethod += "/";
            }
            fullMethod += method;
            this.Namespace = namespaceUrl;
            this.Request = WebRequest.Create(serviceUrl) as HttpWebRequest;
            this.Request.ContentType = "text/xml; charset=utf-8";
            this.Request.Method = "POST";
            this.Request.Accept = "text/xml";
            this.Request.Headers.Add("SOAPAction", fullMethod);
            this.Method = method;
        }

        /// <summary>
        /// Gets or sets the request.
        /// </summary>
        /// <value>
        /// The request.
        /// </value>
        private HttpWebRequest Request { get; set; }

        /// <summary>
        /// Gets or sets the name space.
        /// </summary>
        /// <value>
        /// The name space.
        /// </value>
        private string Namespace { get; set; }

        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        /// <value>
        /// The method.
        /// </value>
        private string Method { get; set; }

        /// <summary>
        /// Builds the soap request envelope.
        /// </summary>
        /// <returns>The soap envelope.</returns>
        public string BuildEnvelope()
        {
            return this.BuildEnvelope(new Dictionary<string, string>());
        }

        /// <summary>
        /// Builds the soap request envelope.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The soap envelope.</returns>
        public string BuildEnvelope(Dictionary<string, string> parameters)
        {
            var sb = new StringBuilder(
@"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""no""?>
<soap:Envelope 
        xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/""
        xmlns:xs=""http://www.w3.org/2001/XMLSchema""
        xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"">
    <soap:Body>");

            sb.Append(
                string.Format(
                    "<{0} xmlns=\"{1}\">",
                    this.Method,
                    this.Namespace));

            foreach (var kvp in parameters)
            {
                sb.Append(
                    string.Format(
                        "<{0}>{1}</{0}>",
                        kvp.Key,
                        kvp.Value));
            }

            sb.Append(string.Format("</{0}>", this.Method));

            sb.Append("</soap:Body></soap:Envelope>");
            return sb.ToString();
        }

        /// <summary>
        /// Sends the specified SOAP envelope.
        /// </summary>
        /// <param name="soap">The SOAP envelope.</param>
        /// <returns>The soap response.</returns>
        public string Send(string soap)
        {
            using (var writer = new StreamWriter(
                        this.Request.GetRequestStream(),
                        Encoding.UTF8))
            {
                writer.Write(soap);
            }

            var r = Request.GetResponse() as HttpWebResponse;

            using (var stream = r.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
