/// ServiceDescriptor.cs
/// Thomas Kempton 2012
///

namespace SoapClient.Service
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;
    using System.Collections.ObjectModel;

    public class ServiceDescriptor
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [XmlAttribute]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the service URL.
        /// </summary>
        /// <value>
        /// The service URL.
        /// </value>
        public string ServiceUrl { get; set; }

        /// <summary>
        /// Gets or sets the namespace URL.
        /// </summary>
        /// <value>
        /// The namespace URL.
        /// </value>
        public string NamespaceUrl { get; set; }

        /// <summary>
        /// Gets or sets the methods.
        /// </summary>
        /// <value>
        /// The methods.
        /// </value>
        [XmlArrayItem(ElementName = "Method")]
        public Collection<ServiceMethod>Methods { get; set; }
    }
}
