// <copyright file="Plugin.cs" company="TheFrenchyDev">
// This file is part of CustomEventHandler.
// CustomEventHandler is licensed under the MIT License.
// See the LICENSE file in the project root for more information.
// </copyright>

namespace CustomEventHandler;

using System;
using LabApi.Features;
using LabApi.Loader.Features.Plugins.Enums;

/// <summary>
/// Main plugin class for CustomEventHandler.
/// This plugin provides a convenient way to automatically register and manage events in SCP:SL plugins.
/// </summary>
public class Plugin : LabApi.Loader.Features.Plugins.Plugin<Config>
{
    /// <summary>
    /// Gets the name of the plugin.
    /// </summary>
    public override string Name => "CustomEventHandler";

    /// <summary>
    /// Gets the author of the plugin.
    /// </summary>
    public override string Author => "TheFrenchyDev";

    /// <summary>
    /// Gets the description of the plugin.
    /// </summary>
    public override string Description => "Plugin responsible for providing developers with an easy-to-use EventsContainer that automatically registers events present in the namespace provided in the EventsContainer.GetEvents() method call.";

    /// <summary>
    /// Gets the version of the plugin.
    /// </summary>
    public override Version Version => new(1, 0, 0);

    /// <summary>
    /// Gets the required LabAPI version.
    /// </summary>
    public override Version RequiredApiVersion => new(LabApiProperties.CompiledVersion);

    /// <summary>
    /// Gets the load priority of the plugin.
    /// </summary>
    public override LoadPriority Priority => LoadPriority.High;
    
    /// <summary>
    /// Example usage: 
    /// </summary>
    /// private IEventList Events => EventsContainer.GetEvents("TemplateTest.Events");

    /// <summary>
    /// Called when the plugin is enabled.
    /// Use this method to register your events by calling Events.RegisterEvents().
    /// </summary>
    public override void Enable()
    {
        // Example usage:
        // Events.RegisterEvents();
    }

    /// <summary>
    /// Called when the plugin is disabled.
    /// Use this method to unregister your events by calling Events.UnregisterEvents().
    /// </summary>
    public override void Disable()
    {
        // Example usage:
        // Events.UnregisterEvents();
    }
}
