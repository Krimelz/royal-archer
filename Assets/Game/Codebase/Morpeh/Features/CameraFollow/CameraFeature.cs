using Game.Codebase.Morpeh.Features.CameraFollow.Systems;
using Scellecs.Morpeh.Elysium;

namespace Game.Codebase.Morpeh.Features.CameraFollow
{
    public class CameraFeature : IEcsFeature
    {
        public void Configure(EcsStartup.FeatureBuilder builder)
        {
            builder
                .AddLateSystemInjected<CameraLookSystem>()
                ;
        }
    }
}