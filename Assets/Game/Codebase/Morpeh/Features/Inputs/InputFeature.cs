using Scellecs.Morpeh.Elysium;
using Game.Codebase.Morpeh.Features.Inputs.Systems;
using UnityEngine;

namespace Game.Codebase.Morpeh.Features.Inputs
{
    public class InputFeature : IEcsFeature
    {
        public void Configure(EcsStartup.FeatureBuilder builder)
        {
            builder
                .AddInitializerInjected<InitializeInputSystem>()
                .AddUpdateSystemInjected<EmitInputSystem>()
                ;
        }
    }
}