using System.Collections.Generic;
using System.Xml.Serialization;

namespace Witsml.Data
{
    [XmlRoot("logs", Namespace = "http://www.witsml.org/schemas/1series")]
    public class WitsmlLogs : IWitsmlGrowingDataQueryType
    {
        [XmlAttribute("version")]
        public string Version = "1.4.1.1";

        [XmlElement("log")]
        public List<WitsmlLog> Logs { get; set; } = new();

        public string TypeName => "log";
    }
}
