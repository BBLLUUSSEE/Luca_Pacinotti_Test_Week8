using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esercitazione.Week8.WPF.Models
{
    public interface IGiftCardRepository
    {
        public IList<GiftCard> GetAll();
    }
}
