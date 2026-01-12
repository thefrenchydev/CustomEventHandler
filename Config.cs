// <copyright file="Config.cs" company="TheFrenchyDev">
// This file is part of CustomEventHandler.
// CustomEventHandler is licensed under the MIT License.
// See the LICENSE file in the project root for more information.
// </copyright>

namespace CustomEventHandler;

/// <summary>
/// Configuration class for the CustomEventHandler plugin.
/// </summary>
public class Config
{
    /// <summary>
    /// Gets or sets a value indicating whether debug mode is enabled.
    /// When enabled, additional logging information will be displayed.
    /// </summary>
    public bool Debug { get; set; }
    #if DEBUG
     = true;
    #else
     = false;
    #endif
}
