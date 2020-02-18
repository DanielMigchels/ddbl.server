using System;

namespace MessageProject
{
    [Serializable]
    public class EncapsulatedMessage
    {
        public MessageType MessageType { get; private set; }
        private readonly object _data;

        public EncapsulatedMessage(MessageType messageType, object data)
        {
            MessageType = messageType;
            _data = data;
        }

        public T GetData<T>()
        {
            return (T)_data;
        }
    }
}
