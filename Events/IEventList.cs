namespace CustomEventHandler.Events;

using System.Collections.Generic;

public interface IEventList : IEnumerable<IEventType> { }

public sealed class EventList : List<IEventType>, IEventList
{
    public EventList() { }
    public EventList(IEnumerable<IEventType> source) : base(source) { }
}
