using HR.Share.PublicShare.Event;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace PrismUICommon.ViewModels
{
    public class UserControl2ViewModel : BindableBase
    {
        IEventAggregator _ea;

        private ObservableCollection<string> _messages;
        public ObservableCollection<string> Messages
        {
            get { return _messages; }
            set { SetProperty(ref _messages, value); }
        }

        public UserControl2ViewModel(IEventAggregator ea)
        {
            _ea = ea;
            Messages = new ObservableCollection<string>();

            _ea.GetEvent<MessageSentEvent>().Subscribe(MessageReceived, ThreadOption.PublisherThread, false, (filter) => filter.Contains("Brian"));
        }

        private void MessageReceived(string message)
        {
            Messages.Add(message);
        }
    }
}
