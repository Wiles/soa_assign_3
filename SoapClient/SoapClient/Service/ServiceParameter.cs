/// ServiceParameter.cs
/// Thomas Kempton 2012
///

namespace SoapClient.Service
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    public class ServiceParameter
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
        /// Gets or sets the type of the parameter.
        /// </summary>
        /// <value>
        /// The type of the parameter.
        /// </value>
        [XmlAttribute(AttributeName = "Type")]
        public string ParameterType { get; set; }
    }
}
