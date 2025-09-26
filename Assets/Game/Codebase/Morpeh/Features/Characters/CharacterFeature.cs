using Scellecs.Morpeh.Elysium;
using Game.Codebase.Morpeh.Features.Characters.Systems;

namespace Game.Codebase.Morpeh.Features.Characters
{
    public class CharacterFeature : IEcsFeature
    {
        public void Configure(EcsStartup.FeatureBuilder builder)
        {
            builder
                .AddUpdateSystemInjected<SetCharacterBowDirectionByInputSystem>()
                ;
        }
    }
}