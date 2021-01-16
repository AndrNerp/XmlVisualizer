using System;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using XmlVisualizer.Messages;

namespace XmlVisualizer.MessageBoxes
{
    public class PassUrlMessageBoxVM : BaseMsgBoxVM
    {
        private string _text;
        private RelayCommand<string> _okCommand;
        protected Action<string> CallbackAction;

        public PassUrlMessageBoxVM(string title = "Pass Url") : base(new PassUrlMessageBox() { Owner = Application.Current.MainWindow }, title)
        {
            Text = "Введите URL в текстовое поле";
            Messenger.Default.Register<PassUrlMessage>(this, PassUrlMessageHandler);
        }

        public string Text
        {
            get { return _text; }
            set { Set(() => Text, ref _text, value); }
        }

        private void PassUrlMessageHandler(PassUrlMessage msg)
        {
            CallbackAction = msg.Callback;
        }

        public RelayCommand<string> OkCommand => _okCommand ?? (_okCommand = new RelayCommand<string>(PassUrl));

        private void PassUrl(string url)
        {
            bool result = Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
                          && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            if (result)
            {
                CallbackAction(url);
                _view.Close();
                return;
            }

            MessageBox.Show("Incorrect Url");
        }
    }
}
