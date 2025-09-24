using Game.Codebase.Morpeh.Features.CameraFollow.Systems;
using Scellecs.Morpeh.Elysium;

namespace Game.Codebase.Morpeh.Features.CameraFollow
{
    public class CameraFollowFeature : IEcsFeature
    {
        public void Configure(EcsStartup.FeatureBuilder builder)
        {
            builder
                .AddLateSystemInjected<CameraFollowSystem>()
                ;
        }
    }
}