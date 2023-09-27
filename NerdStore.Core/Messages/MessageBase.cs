using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Core.Messages
{
    public abstract class MessageBase
    {
        public string MessageType { get; protected set; }
        public Guid IdAggregate { get; protected set; }
        public MessageBase()
        {
            MessageType = GetType().Name;
        }
    }
}
