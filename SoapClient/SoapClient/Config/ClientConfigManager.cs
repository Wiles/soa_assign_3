/// ClientConfigManager.cs
///
///

namespace SoapClient.Config
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.IO;

    public class ClientConfigManager<T> where T : class, new()
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ClientConfigManager{T}" /> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public ClientConfigManager(string filePath)
        {
            this.Cerealizer = new XmlSerializer(typeof(T));
            this.FilePath = filePath;
            this.Configuration = new T();
        }

        /// <summary>
        /// Gets or sets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public T Configuration { get; private set; }

        /// <summary>
        /// Gets or sets the cerealizer.
        /// </summary>
        /// <value>
        /// The cerealizer.
        /// </value>
        private XmlSerializer Cerealizer { get; set; }

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        /// <value>
        /// The file path.
        /// </value>
        private string FilePath { get; set; }

        /// <summary>
        /// Loads the configuration from file.
        /// </summary>
        public void Load()
        {
            using (var stream = new FileStream(this.FilePath, FileMode.Open))
            {
                var obj = this.Cerealizer.Deserialize(stream);
                this.Configuration = obj as T;
            }
        }

        /// <summary>
        /// Saves the configuration to file.
        /// </summary>
        public void Save()
        {
            using (var stream = new FileStream(
                    this.FilePath,
                    FileMode.OpenOrCreate))
            {
                this.Cerealizer.Serialize(stream, this.Configuration);
            }
        }
    }
}
