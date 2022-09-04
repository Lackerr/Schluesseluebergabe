using Schluesseluebergabe.Commands;
using Schluesseluebergabe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Schluesseluebergabe.ViewModels
{
    public class CreateNewHandoverViewModel : ViewModelBase
    {
        //private string _recipientName = string.Empty;
        //private string _recipientForename = string.Empty;
        //private string _recipientId = string.Empty;

        //private string _senderName = string.Empty;
        //private string _senderForename = string.Empty;

        private Sender _sender = new Sender();
        private Recipient _recipient = new Recipient();
        private KeyInformation _key = new KeyInformation();
        private GeoData _geoData = new GeoData();


        public string RecipientName
        {
            get => _recipient.Name;
            set
            {
                _recipient.Name = value;
                OnPropertyChanged(nameof(RecipientName));
            }
        }
        public string RecipientForeName
        {
            get { return _recipientForename; }
            set
            {
                _recipientForename = value;
                OnPropertyChanged(nameof(RecipientForeName));
            }
        }
        public string RecipientId
        {
            get { return _recipientId; }
            set
            {
                _recipientId = value;
                OnPropertyChanged(nameof(RecipientId));
            }
        }

        public string SenderName
        {
            get { return _senderName; }
            set
            {
                _sender.Name = value;
                _senderName = value;
                OnPropertyChanged(nameof(SenderName));
            }
        }
        public string SenderForename
        {
            get { return _senderForename; }
            set
            {
                _senderForename = value;
                OnPropertyChanged(nameof(SenderForename));
            }
        }

        public ICommand SubmitCommand { get; }

        public CreateNewHandoverViewModel()
        {
            SubmitCommand = new SubmitPrintCommand(this);
        }
    }
}
