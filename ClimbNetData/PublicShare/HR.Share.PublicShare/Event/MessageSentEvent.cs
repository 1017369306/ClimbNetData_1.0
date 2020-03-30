using Prism.Events;
using System.Windows.Media;

namespace HR.Share.PublicShare.Event
{
    public class MessageSentEvent : PubSubEvent<string>
    {

    }

    public class MessageDictionarySentEvent : PubSubEvent<MessageDictionaryBase>
    {

    }
    /// <summary>
    /// MessageDictionarySentEvent的实体类
    /// </summary>
    public class MessageDictionaryBase : EventBase
    {
        private string _key;
        private object _value;
        private ImageSource _image;
        public string Key { get => _key; set => _key = value; }
        public object Value { get => _value; set => _value = value; }
        public ImageSource Image { get => _image; set => _image = value; }
    }

    public class ceshi
    {
        public string _key;
    }
}
