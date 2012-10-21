/// ClientConfig.cs
/// Thomas Kempton 2012
///

namespace SoapClient.Config
{
    using System.Collections.ObjectModel;
    using System.Xml.Serialization;
    using SoapClient.Service;

    public class ClientConfig
    {
        /// <summary>
        /// Gets or sets the services.
        /// </summary>
        /// <value>
        /// The services.
        /// </value>
        [XmlArrayItem(ElementName = "Service")]
        public Collection<ServiceDescriptor> Services { get; set; }
    }
}
