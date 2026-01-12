// <copyright file="IEventList.cs" company="TheFrenchyDev">
// This file is part of CustomEventHandler.
// CustomEventHandler is licensed under the MIT License.
// See the LICENSE file in the project root for more information.
// </copyright>

namespace CustomEventHandler.Events;

using System.Collections.Generic;

/// <summary>
/// Interface representing a collection of event handlers.
/// </summary>
public interface IEventList : IEnumerable<IEventType> { }

/// <summary>
/// Implementation of <see cref="IEventList"/> that stores event handlers.
/// </summary>
public sealed class EventList : List<IEventType>, IEventList
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EventList"/> class.
    /// </summary>
    public EventList() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EventList"/> class with a collection of events.
    /// </summary>
    /// <param name="source">The collection of events to initialize the list with.</param>
    public EventList(IEnumerable<IEventType> source) : base(source) { }
}
