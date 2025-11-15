using Game.Codebase.Morpeh.Features.Cameras.Systems;
using Scellecs.Morpeh.Elysium;

namespace Game.Codebase.Morpeh.Features.Cameras
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