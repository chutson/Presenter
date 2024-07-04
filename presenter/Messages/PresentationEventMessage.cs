using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presenter.Messages
{
    internal class PresentationEventMessage(PresentationEventType eventType)
    {
        public PresentationEventType EventType { get; } = eventType;
    }

    internal enum PresentationEventType
    {
        Start,
        Stop,
        Next,
        Previous
    }
}
