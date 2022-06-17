using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Esercitazione.Week8.WPF.Messages
{
    public class DialogMessage
    {
        public string Content { get; set; } = null;
        public string Title { get; set; } = "Informazione";
        public MessageBoxImage Icon { get; set; } = MessageBoxImage.Information;
        public MessageBoxButton Button { get; set; } = MessageBoxButton.OK;
    }
}
