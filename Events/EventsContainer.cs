namespace CustomEventHandler.Events;

using System.Linq;
using System.Reflection;

public static class EventsContainer
{
    public static string RegisterMethod => "Register";
    public static string UnregisterMethod => "Unregister";

    /// <summary>
    /// Returns the list of every events present in the namespace only if they implement the interface <see cref="FasterAPI.Events.IEventType"/>.
    /// </summary>
    /// <param name="namespaceName">Le namespace contenant tous les events</param>
    /// <returns>The <see cref="FasterAPI.Events.IEventList"/> containing all events.</returns>
    public static IEventList GetEvents(string namespaceName)
    {
        Assembly callingAssembly = Assembly.GetCallingAssembly();
        return new EventList(callingAssembly.GetTypes().Where(t =>
                t.Namespace == namespaceName
                && t.IsClass
                && t.GetConstructor([]) is not null
                && t.GetMethod(RegisterMethod) is not null
                && t.GetMethod(UnregisterMethod) is not null
            ).Select(t => (IEventType)t.GetConstructor([]).Invoke(null)));
    }

    /// <summary>
    /// Registers all events. Call this method in the plugin Enable method.
    /// </summary>
    /// <param name="events">The <see cref="FasterAPI.Events.IEventList"/> containing all events.</param>
    /// <returns>void</returns>
    public static void RegisterEvents(this IEventList events)
    {
        foreach (var eventType in events)
            eventType.Register();
    }

    /// <summary>
    /// Unregisters all events. Call this method in the plugin Disable method.
    /// </summary>
    /// <param name="events">The <see cref="FasterAPI.Events.IEventList"/> containing all events.</param>
    /// <returns>void</returns>
    public static void UnregisterEvents(this IEventList events)
    {
        foreach (var eventType in events)
            eventType.Unregister();
    }
}