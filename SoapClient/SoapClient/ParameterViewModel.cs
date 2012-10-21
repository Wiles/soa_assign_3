/// ParameterViewModel.cs
/// Thomas Kempton 2012
///

namespace SoapClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ParameterViewModel
    {
        /// <summary>
        /// Gets or sets the parameter.
        /// </summary>
        /// <value>
        /// The parameter.
        /// </value>
        public string Parameter { get; set; }

        /// <summary>
        /// Gets or sets the type of the parameter.
        /// </summary>
        /// <value>
        /// The type of the parameter.
        /// </value>
        public string ParameterType { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }
    }
}
