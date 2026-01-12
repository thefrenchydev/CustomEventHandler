namespace CustomEventHandler;

using System;
using LabApi.Features;
using LabApi.Loader.Features.Plugins.Enums;

public class Plugin : LabApi.Loader.Features.Plugins.Plugin<Config>
{
    public override string Name => "CustomEventHandler";
    public override string Author => "TheFrenchyDev";
    public override string Description => "Plugin responsible for providing developers with an easy-to-use EventsContainer that automatically registers events present in the namespace provided in the EventsContainer.GetEvents() method call.";
    public override Version Version => new(1, 0, 0);
    public override Version RequiredApiVersion => new(LabApiProperties.CompiledVersion);
    public override LoadPriority Priority => LoadPriority.High;

    public override void Enable()
    {
        
    }

    public override void Disable()
    {
        
    }
}
