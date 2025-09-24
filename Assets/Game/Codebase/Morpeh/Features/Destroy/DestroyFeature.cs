using Game.Codebase.Morpeh.Features.Destroy.Systems;
using Scellecs.Morpeh.Elysium;

namespace Game.Codebase.Morpeh.Features.Destroy
{
    public class DestroyFeature : IEcsFeature
    {
        public void Configure(EcsStartup.FeatureBuilder builder)
        {
            builder
                .AddCleanupSystemInjected<RemoveEntityOnDestroySystem>()
                ;
        }
    }
}
