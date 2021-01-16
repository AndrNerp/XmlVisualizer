using System.Xml.Linq;

namespace XmlVisualizer.Messages
{
    public class RenderTreeMsg
    {
        public XDocument Doc { get; set; }

        public RenderTreeMsg(XDocument doc)
        {
            Doc = doc;
        }
    }
}
