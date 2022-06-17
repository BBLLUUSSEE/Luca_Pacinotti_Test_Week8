using Esercitazione.Week8.WPF.Messages;
using Esercitazione.Week8.WPF.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Gift = Esercitazione.Week8.WPF.Models.GiftCard;

namespace Esercitazione.Week8.WPF.ViewsModels.Main
{
    public class MainWindowViewModel : ViewModelBase
    {
        private List<string> _gift;
        private string _selectedItem;
        private string _giftDetails;
        private bool _viewGift = false;
        private string _txtGift;
        private string _mittente;
        private string _destinatatio;
        private string _messaggio;
        private double _importo;
        private string _giftDelete;
        private string _nuovoMittente;
        private string _nuovoDestinatario;

        private IGiftCardRepository _giftRepository = new GiftCardRepositoryMock();

        public string NuovoMittente
        {
            get { return _nuovoMittente; }
            set
            {
                _nuovoMittente = value;
                RaisePropertyChanged();
            }
        }

        public string NuovoDestinatario
        {
            get { return _nuovoDestinatario; }
            set
            {
                _nuovoDestinatario = value;
                RaisePropertyChanged();
            }
        }

        public bool ViewGift
        {
            get { return _viewGift; }
            set { _viewGift = value; RaisePropertyChanged(); }
        }

        public List<string> Gift
        {
            get => _gift;
            set
            {
                _gift = value;
                RaisePropertyChanged();
            }
        }

        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;

                RaisePropertyChanged();
            }
        }

        public string GiftDetails
        {
            get => _giftDetails;
            set
            {
                _giftDetails = value;
                RaisePropertyChanged();
            }
        }

        public string GiftDelete
        {
            get => _giftDelete;
            set
            {
                _giftDelete = value;
                RaisePropertyChanged();
            }
        }

        public string TextGift
        {
            get { return _txtGift; }
            set
            {
                _txtGift = value;
                RaisePropertyChanged();
            }
        }

        public ICommand ViewProductCommand { get; set; }
        public ICommand ShowGiftCommand { get; set; }
        public ICommand DeleteGiftCommand { get; set; }
        public ICommand UpdateGiftCommand { get; set; }
        public ICommand CreateGiftCommand { get; set; }


        public MainWindowViewModel()
        {
            ViewProductCommand = new RelayCommand(ViewProduct);
            ShowGiftCommand = new RelayCommand(UpdateGiftExecute);
            DeleteGiftCommand = new RelayCommand(DeleteGift);
            UpdateGiftCommand = new RelayCommand(UpdateGift);
            CreateGiftCommand = new RelayCommand(CreateGift);

            Gift = _giftRepository.GetAll().Select(p => p.Destinatario).ToList();
        }

        private void DeleteGift()
        {

        }

        private void ViewProduct()
        {
            if (SelectedItem != null)
            {
                Gift gift = _giftRepository.GetAll()
                    .FirstOrDefault(p => p.Destinatario.Equals(SelectedItem, StringComparison.InvariantCultureIgnoreCase));
                GiftDetails = gift is null ? "Prodotto non trovato" : gift.ToString();
            }
        }

        private void UpdateGiftExecute()
        {
            if (SelectedItem != null)
            {
                Gift gift = _giftRepository.GetAll()
                    .FirstOrDefault(p => p.Destinatario.Equals(SelectedItem, StringComparison.InvariantCultureIgnoreCase));
                if (gift != null)
                {
                    _mittente = gift.Mittente;
                    _destinatatio = gift.Destinatario;
                    _messaggio = gift.Messaggio;
                    _importo = gift.Importo;


                    TextGift = $"{_mittente} - {_destinatatio} - {_messaggio} - {_importo}";
                }
            }
        }

        private void UpdateGift()
        {
            if (SelectedItem != null)
            {
                Gift gift = _giftRepository.GetAll()
                    .FirstOrDefault(p => p.Destinatario.Equals(SelectedItem, StringComparison.InvariantCultureIgnoreCase));
                if (gift != null)
                {
                    gift.Mittente = _nuovoMittente;
                    gift.Destinatario = _nuovoDestinatario;
                }
            }
            DialogMessage dialog = new DialogMessage { Content = $"Gift aggiornata" };
            Messenger.Default.Send(dialog);
        }

        private void CreateGift()
        {
            var showHomeMessage = new ShowViewMessage
            {
                ViewName = "CreateWindowView"
            };
        }
    }
}
