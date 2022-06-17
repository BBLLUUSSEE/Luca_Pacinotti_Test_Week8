using Esercitazione.Week8.WPF.Messages;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;

namespace Esercitazione.Week8.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Messenger.Default.Register<DialogMessage>(this, OnDialogMessage);
        }

        private void OnDialogMessage(DialogMessage msg)
        {
            var result = MessageBox.Show(
                msg.Content,
                msg.Title,
                msg.Button,
                msg.Icon);
        }
    }
}
