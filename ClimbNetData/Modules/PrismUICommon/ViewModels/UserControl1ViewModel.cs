using HR.Share.PublicShare.Event;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace PrismUICommon.ViewModels
{
    public class UserControl1ViewModel : BindableBase
    {
        IEventAggregator _ea;

        private string _message = "Message to Send";
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public DelegateCommand SendMessageCommand { get; private set; }

        public UserControl1ViewModel(IEventAggregator ea)
        {
            _ea = ea;
            SendMessageCommand = new DelegateCommand(SendMessage);
        }

        private void SendMessage()
        {
            _ea.GetEvent<MessageSentEvent>().Publish(Message);
        }
    }
}
