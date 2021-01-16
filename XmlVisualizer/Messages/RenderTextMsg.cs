using System.Xml.Linq;

namespace XmlVisualizer.Messages
{
    public class RenderTextMsg
    {
        public XDocument Doc { get; set; }

        public RenderTextMsg(XDocument doc)
        {
            Doc = doc;
        }
    }
}
