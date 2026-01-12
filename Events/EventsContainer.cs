// <copyright file="EventsContainer.cs" company="TheFrenchyDev">
// This file is part of CustomEventHandler.
// CustomEventHandler is licensed under the MIT License.
// See the LICENSE file in the project root for more information.
// </copyright>

namespace CustomEventHandler.Events;

using System.Linq;
using System.Reflection;

/// <summary>
/// Container for managing event registration and unregistration.
/// This class automatically discovers and manages events implementing <see cref="IEventType"/> in a given namespace.
/// </summary>
public static class EventsContainer
{
    /// <summary>
    /// Gets the name of the method used to register events.
    /// </summary>
    public static string RegisterMethod => "Register";

    /// <summary>
    /// Gets the name of the method used to unregister events.
    /// </summary>
    public static string UnregisterMethod => "Unregister";

    /// <summary>
    /// Discovers and returns all event classes in the specified namespace.
    /// Only classes implementing <see cref="IEventType"/> with a parameterless constructor,
    /// Register, and Unregister methods will be included.
    /// </summary>
    /// <param name="namespaceName">The namespace containing all event classes (e.g., "YourPlugin.Events").</param>
    /// <returns>An <see cref="IEventList"/> containing all discovered event instances.</returns>
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
    /// Registers all events in the event list.
    /// Call this method in your plugin's Enable() method to subscribe to all events.
    /// </summary>
    /// <param name="events">The <see cref="IEventList"/> containing all events to register.</param>
    public static void RegisterEvents(this IEventList events)
    {
        foreach (var eventType in events)
            eventType.Register();
    }

    /// <summary>
    /// Unregisters all events in the event list.
    /// Call this method in your plugin's Disable() method to unsubscribe from all events.
    /// </summary>
    /// <param name="events">The <see cref="IEventList"/> containing all events to unregister.</param>
    public static void UnregisterEvents(this IEventList events)
    {
        foreach (var eventType in events)
            eventType.Unregister();
    }
}