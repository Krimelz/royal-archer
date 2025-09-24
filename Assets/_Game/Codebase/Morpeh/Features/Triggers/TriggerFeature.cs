using Scellecs.Morpeh.Elysium;
using Game.Codebase.Morpeh.Features.Triggers.Systems;

namespace Game.Codebase.Morpeh.Features.Triggers
{
    public class TriggerFeature : IEcsFeature
    {
        public void Configure(EcsStartup.FeatureBuilder builder)
        {
            builder
                .AddFixedSystemInjected<ActivateTriggerSystem>()
                .AddFixedSystemInjected<SetTriggerSpriteStateSystem>()
                .AddUpdateSystemInjected<InteractWithTriggerSystem>()
                .AddFixedSystemInjected<DisableAllTriggersSystem>()
                ;
        }
    }
}