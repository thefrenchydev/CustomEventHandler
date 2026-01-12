namespace CustomEventHandler.Events;

/// <summary>
/// Interface used to implement an Event that will be added to the CustomEventHandler automatically.
/// </summary>
public interface IEventType
{
    /// <summary>
    /// Method called when registering the event.
    /// </summary>
    void Register();

    /// <summary>
    /// Method called when unregistering the event.
    /// </summary>
    void Unregister();
} 