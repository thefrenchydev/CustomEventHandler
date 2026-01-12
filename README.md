# CustomEventHandler

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![.NET Framework 4.8](https://img.shields.io/badge/.NET%20Framework-4.8-blue.svg)](https://dotnet.microsoft.com/download/dotnet-framework/net48)
[![LabAPI](https://img.shields.io/badge/LabAPI-1.1.4-green.svg)](https://www.nuget.org/packages/Northwood.LabAPI/)

A powerful and easy-to-use event management framework for SCP: Secret Laboratory plugins using LabAPI. CustomEventHandler automatically discovers, registers, and manages your event handlers, eliminating boilerplate code and streamlining plugin development.

## 🌟 Features

- **Automatic Event Discovery**: Automatically finds and registers all event classes in a specified namespace
- **Simple Integration**: Just implement `IEventType` and your events are ready to go
- **Clean Code**: Reduces boilerplate with automatic registration/unregistration
- **Type-Safe**: Uses reflection to ensure only valid event handlers are registered
- **High Performance**: Minimal overhead with efficient event management
- **Easy Debugging**: Built-in debug configuration for development

## 📋 Requirements

- SCP: Secret Laboratory Dedicated Server
- LabAPI 1.1.4 or higher
- .NET Framework 4.8

## 📦 Installation

### For Plugin Developers (Using CustomEventHandler in your plugin)

1. Download the latest `CustomEventHandler.dll` from the [Releases](../../releases) page
2. Place it in your server's `LabMods/dependencies` folder
3. Add a reference to `CustomEventHandler.dll` in your plugin project
4. Start using the event management features!

### For Server Owners

1. Download the latest `CustomEventHandler.dll` from the [Releases](../../releases) page
2. Place it in your server's `LabMods/dependencies` folder
3. Restart your server

## 🚀 Quick Start

### Creating an Event Handler

Create a class that implements `IEventType` with `Register()` and `Unregister()` methods:

```csharp
using CustomEventHandler.Events;

namespace YourPlugin.Events;

public class PlayerJoinedEvent : IEventType
{
    // Subscribe to the event
    public void Register() =>
        PlayerEvents.PlayerJoined += OnPlayerJoined;

    // Unsubscribe from the event
    public void Unregister() =>
        PlayerEvents.PlayerJoined -= OnPlayerJoined;

    private void OnPlayerJoined(PlayerJoinedEvent ev)
    {
        // Your event logic here
        Log.Info($"{ev.Player.Nickname} joined the server!");
    }
}

```

### Using in Your Plugin

In your main plugin class:

```csharp
using CustomEventHandler.Events;
using LabApi.Loader.Features.Plugins;

namespace YourPlugin
{
    public class MyPlugin : Plugin<Config>
    {
        private IEventList Events => EventsContainer.GetEvents("YourPlugin.Events");

        public override void Enable()
        {
            // Automatically discover and register all events in your Events namespace
            Events.RegisterEvents();

            Log.Info("Plugin enabled with all events registered!");
        }

        public override void Disable()
        {
            // Unregister all events when plugin is disabled
            Events.UnregisterEvents();

            Log.Info("Plugin disabled and events unregistered!");
        }
    }
}
```

## 📖 How It Works

1. **Event Discovery**: `EventsContainer.GetEvents("YourNamespace")` scans the specified namespace for classes implementing `IEventType`
2. **Validation**: Only classes with a parameterless constructor and both `Register()` and `Unregister()` methods are included
3. **Registration**: `RegisterEvents()` calls the `Register()` method on each discovered event
4. **Cleanup**: `UnregisterEvents()` calls the `Unregister()` method to properly clean up when your plugin is disabled

## 🎯 API Reference

### `IEventType` Interface

All event handlers must implement this interface:

```csharp
public interface IEventType
{
    void Register();    // Called when registering the event
    void Unregister();  // Called when unregistering the event
}
```

### `EventsContainer` Class

Static class providing event management functionality:

#### Methods

- **`GetEvents(string namespaceName)`**

  - Discovers all event classes in the specified namespace
  - Returns: `IEventList` containing all discovered events
  - Example: `EventsContainer.GetEvents("YourPlugin.Events")`

- **`RegisterEvents(this IEventList events)`**

  - Extension method to register all events in the list
  - Call in your plugin's `Enable()` method
  - Example: `events.RegisterEvents()`

- **`UnregisterEvents(this IEventList events)`**
  - Extension method to unregister all events in the list
  - Call in your plugin's `Disable()` method
  - Example: `events.UnregisterEvents()`

## 🔧 Configuration

The plugin includes a simple configuration file (`CustomEventHandler.yml`):

```yaml
# Enable debug logging
debug: true
```

## 💡 Best Practices

1. **Namespace Organization**: Keep all your event handlers in a dedicated namespace (e.g., `YourPlugin.Events`)
2. **Proper Cleanup**: Always unregister events in your `Disable()` method to prevent memory leaks
3. **Parameterless Constructors**: Ensure all event classes have a parameterless constructor
4. **Event Storage**: Store the `IEventList` as a field in your plugin class for easy access during disable

## 🛠️ Building from Source

```bash
# Clone the repository
git clone https://github.com/YourUsername/CustomEventHandler.git
cd CustomEventHandler

# Set the LABAPI_REFERENCES environment variable to your LabAPI references folder
# Example: set LABAPI_REFERENCES=C:\Path\To\LabAPI\References

# Build the project
dotnet build -c Release

# The compiled DLL will be in bin/Release/net48/
```

## 🤝 Contributing

Contributions are welcome! Please feel free to submit a Pull Request. For major changes, please open an issue first to discuss what you would like to change.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👤 Author

**TheFrenchyDev**

## 🙏 Acknowledgments

- LabAPI team for the excellent SCP:SL modding framework
- The SCP:SL community for continued support

## 📞 Support

If you encounter any issues or have questions:

- Open an issue on [GitHub Issues](../../issues)
- Check existing issues for solutions
- Provide detailed information about your setup and the problem

## 📊 Version History

### v1.0.0

- Initial release
- Automatic event discovery and registration
- Support for LabAPI 1.1.4
- Clean and documented API

---

**Note**: This plugin is designed to be used as a dependency for other plugins. It does not add any gameplay features on its own, but provides a framework for easier event management in your own plugins.
