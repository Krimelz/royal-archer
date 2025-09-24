using Scellecs.Morpeh.Elysium;
using Game.Codebase.Morpeh.Features.Movement.Systems;

namespace Game.Codebase.Morpeh.Features.Movement
{
    public class MovementFeature : IEcsFeature
    {
        public void Configure(EcsStartup.FeatureBuilder builder)
        {
            builder
                .AddUpdateSystemInjected<UpdatePositionsSystem>()
                .AddUpdateSystemInjected<SetTransformPositionSystem>()
                ;
        }
    }
}