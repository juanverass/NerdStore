using MediatR;

namespace NerdStore.Core.Messages
{
    public abstract class Event : MessageBase, INotification
    {
        public DateTime DataHora { get; private set; }
        public Event()
        {
            DataHora = DateTime.Now;
        }
    }
}
