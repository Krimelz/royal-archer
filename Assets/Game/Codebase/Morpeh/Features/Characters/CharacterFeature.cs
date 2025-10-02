using Game.Codebase.Morpeh.Features.Characters.Systems;
using Scellecs.Morpeh.Elysium;

namespace Game.Codebase.Morpeh.Features.Characters
{
    public class CharacterFeature : IEcsFeature
    {
        public void Configure(EcsStartup.FeatureBuilder builder)
        {
            builder
                .AddUpdateSystemInjected<SetCharacterSpeedByInput>()
                .AddUpdateSystemInjected<SetCharacterDirectionByInput>()
                ;
        }
    }
}