using Game.Codebase.Morpeh.Features.Common.Systems;
using Scellecs.Morpeh.Elysium;

namespace Game.Codebase.Morpeh.Features.Common
{
    public class CommonFeature : IEcsFeature
    {
        public void Configure(EcsStartup.FeatureBuilder builder)
        {
            builder
                .AddUpdateSystemInjected<SetTransformPositionSystem>()
                ;
        }
    }
}