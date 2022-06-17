using Esercitazione.Week8.WPF.Messages;
using Esercitazione.Week8.WPF.Views.Create;
using Esercitazione.Week8.WPF.ViewsModels.Main;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Esercitazione.Week8.WPF.Views.Main
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();

            MainWindowViewModel vm = new MainWindowViewModel();
            this.DataContext = vm;


            // Mi registro ai messaggi che sono in grado di soddisfare
            Messenger.Default.Register<ShowViewMessage>(this, OnShowViewMessage);
        }

        private void OnShowViewMessage(ShowViewMessage msg)
        {
            if (msg.ViewName == "CreateWindowView")
            {
                CreateWindowView view = new CreateWindowView();
                view.DataContext = new CreateWindowView();

                view.Show();

                this.Close();
            }
        }
    }
}
