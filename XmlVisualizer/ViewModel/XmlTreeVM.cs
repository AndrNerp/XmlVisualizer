using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using XmlVisualizer.Messages;
using XmlVisualizer.TreeHelpers;

namespace XmlVisualizer.ViewModel
{
    public class XmlTreeVM : ViewModelBase
    {
        private ObservableCollection<XmlTreeNode> _rootNodeCollection;
        private XDocument Document { get; set; }

        public ObservableCollection<XmlTreeNode> RootNodeCollection
        {
            get { return _rootNodeCollection ?? (_rootNodeCollection = new ObservableCollection<XmlTreeNode>()); }
            set { Set(() => RootNodeCollection, ref _rootNodeCollection, value); }
        }

        public XmlTreeVM()
        {
            Messenger.Default.Register<RenderTreeMsg>(this, RenderTreeMsgHandler);
        }

        private void RenderTreeMsgHandler(RenderTreeMsg msg)
        {
            Document = msg.Doc;
            RootNodeCollection.Clear();
            RootNodeCollection.Add(new XmlTreeNode());
            BuildNodes(RootNodeCollection.First(), Document.Root);
        }

        private void BuildNodes(XmlTreeNode node, XElement xElement)
        {
            node.OwnValue = xElement.Value;
            node.OwnName = xElement.Name.LocalName;

            if (xElement.HasAttributes)
            {
                foreach (var att in xElement.Attributes())
                {
                    node.Attributes.Add(new Tuple<string, string>(att.Name.LocalName, att.Value));
                }
            }

            if (!xElement.HasElements) return;
            foreach (XElement childElement in xElement.Elements())
            {
                var child = new XmlTreeNode();
                node.Children.Add(child);
                BuildNodes(child, childElement);
            }
        }
    }
}
