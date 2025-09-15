namespace Presenter.Services.Messages
{
    public class PresentationEventMessage(PresentationEventType eventType)
    {
        public PresentationEventType EventType { get; } = eventType;
    }

    public enum PresentationEventType
    {
        Start,
        Stop,
        Next,
        Previous
    }
}
