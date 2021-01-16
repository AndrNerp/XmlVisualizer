using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace XmlVisualizer.TreeHelpers
{
    public class XmlTreeNode
    {
        private ObservableCollection<XmlTreeNode> _children;
        private List<Tuple<string, string>> _attributes;

        public XmlTreeNode()
        {

        }

        public string OwnValue { get; set; }
        public string OwnName { get; set; }

        public List<Tuple<string, string>> Attributes
        {
            get
            {
                return _attributes ?? (_attributes = new List<Tuple<string, string>>());
            }
            set
            {
                _attributes = value;
            }
        }

        public ObservableCollection<XmlTreeNode> Children
        {
            get
            {
                return _children ?? (_children = new ObservableCollection<XmlTreeNode>());
            }
            set
            {
                _children = value;
            }
        }
    }
}
