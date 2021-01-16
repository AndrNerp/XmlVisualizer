using System;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using XmlVisualizer.MessageBoxes;
using XmlVisualizer.Messages;

namespace XmlVisualizer.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand _passUrlCommand;
        private RelayCommand _renderTreeCommand;

        public MainViewModel()
        {
        }

        private XDocument Document { get; set; }

        public RelayCommand PassUrlCommand => _passUrlCommand ?? (_passUrlCommand = new RelayCommand(PassUrl));
        public RelayCommand RenderTreeCommand => _renderTreeCommand ?? (_renderTreeCommand = new RelayCommand(RenderTree));


        private void PassUrl()
        {
            var passUrlDialog = new PassUrlMessageBoxVM();
            Messenger.Default.Send(new PassUrlMessage(RenderText));
            passUrlDialog.ShowDialog();
        }

        private void RenderText(string url)
        {
            Document = LoadXmlFromUrl(url);
            Messenger.Default.Send(new RenderTextMsg(Document));
        }

        private void RenderTree()
        {
            if (Document == null)
            {
                MessageBox.Show("Empty xml");
                return;
            }
            Messenger.Default.Send(new RenderTreeMsg(Document));
        }

        private XDocument LoadXmlFromUrl(string url)
        {
            try
            {
                return XDocument.Load(url);
            }
            catch (XmlException e)
            {
                MessageBox.Show($"Incorrect XML file: {Environment.NewLine} {e.Message}");
                return null;
            }
            catch (Exception)
            {
                MessageBox.Show($"Something wrong with web resource");
                return null;
            }
        }
    }
}