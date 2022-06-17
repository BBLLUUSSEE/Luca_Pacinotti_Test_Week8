using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione.Week8.WPF.Models
{
    public class GiftCardRepositoryMock : IGiftCardRepository
    {
        private IList<GiftCard> giftCards = new List<GiftCard>()
        {
            new GiftCard()
            {
                Mittente = "Profumeria",
                Destinatario = "Luca",
                Messaggio = "Questo è un messaggio",
                Importo = 50
            },
            new GiftCard()
            {
                Mittente = "Profumeria",
                Destinatario = "Marco",
                Messaggio = "Questo è un messaggio",
                Importo = 75
            },
            new GiftCard()
            {
                Mittente = "Mario",
                Destinatario = "Anna",
                Messaggio = "Questo è un messaggio",
                Importo = 100
            }
        };
        public IList<GiftCard> GetAll()
        {
            return giftCards;
        }
    }
}
