using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione.Week8.WPF.Models
{
    public class GiftCard
    {
        public string Mittente { get; set; }
        public string Destinatario { get; set; }
        public string Messaggio { get; set; }
        public double Importo { get; set; }

        public override string ToString()
        {
            return $"{Mittente} - {Destinatario} - {Messaggio} - {Importo}€";
        }
    }
}
