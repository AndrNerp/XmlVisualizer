using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace XmlVisualizer.MessageBoxes
{
    public class BaseMsgBoxVM : ViewModelBase
    {
        protected readonly Window _view;

        private RelayCommand _cancelCommand;
        protected bool IsInDialogMode;

        public BaseMsgBoxVM(Window windowView, string title = "Message Box")
        {
            Title = title;
            windowView.DataContext = this;
            _view = windowView;
        }

        public RelayCommand CancelCommand =>
            _cancelCommand
            ?? (_cancelCommand = new RelayCommand(Cancel));

        public string Title { get; }

        public void Show()
        {
            _view.Show();
        }

        public bool? ShowDialog()
        {
            if (IsInDialogMode) return null;

            IsInDialogMode = true;
            return _view.ShowDialog();
        }

        private void Cancel()
        {
            _view.DialogResult = false;
            _view.Close();
        }
    }
}
