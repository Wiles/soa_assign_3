/// ExceptionFactory.cs
/// Thomas Kempton & Samuel Lewis 2012
///

namespace soa_assign_3
{
    using System;
    using System.Web.Services.Protocols;
    using System.Xml;

    /// <summary>
    /// Class for creating SOAP exceptions.
    /// </summary>
    public class ExceptionFactory
    {
        /// <summary>
        /// Prevents a default instance of the 
        /// <see cref="ExceptionFactory" /> class from being created.
        /// </summary>
        public ExceptionFactory(string logPath)
        {
            if (string.IsNullOrEmpty(logPath))
            {
                throw new ArgumentException("logPath is null or empty.");
            }

            this.LogPath = logPath;
        }

        /// <summary>
        /// Gets or sets the log file path.
        /// </summary>
        /// <value>
        /// The log file path.
        /// </value>
        private string LogPath { get; set; }

        /// <summary>
        /// Creates and logs a soap exception.
        /// </summary>
        /// <param name="actor">The actor.</param>
        /// <param name="message">The message.</param>
        /// <param name="details">The details.</param>
        /// <returns>The SOAP exception.</returns>
        public SoapException Create(Uri uri, string message, string details)
        {
            Logger.LogError(
                    this.LogPath,
                    uri.AbsolutePath,
                    message);

            var doc = new XmlDocument();
            doc.AppendChild(doc.CreateElement("details"));
            doc.FirstChild.AppendChild(doc.CreateTextNode(details));

            return new SoapException(
                    message,
                    SoapException.ServerFaultCode,
                    uri.AbsoluteUri,
                    doc,
                    null);
        }
    }
}