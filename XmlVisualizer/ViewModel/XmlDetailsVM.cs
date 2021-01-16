using System.Xml.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using XmlVisualizer.Messages;

namespace XmlVisualizer.ViewModel
{
    public class XmlDetailsVM : ViewModelBase
    {
        private XDocument _document;

        public XmlDetailsVM()
        {
            Messenger.Default.Register<RenderTextMsg>(this, RenderTextMsgHandler);
        }

        public XDocument Document
        {
            get { return _document; }
            set { Set(() => Document, ref _document, value); }
        }

        private void RenderTextMsgHandler(RenderTextMsg msg)
        {
            Document = msg.Doc;
        }
    }

}
