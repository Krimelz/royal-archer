using Game.Codebase.Morpeh.Features.Triggers.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using Sprite = Game.Codebase.Morpeh.Features.Common.Components.Sprite;

namespace Game.Codebase.Morpeh.Features.Triggers.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class SetTriggerSpriteStateSystem : IFixedSystem
    {
        private Stash<Sprite> _sprites;
        private Stash<ActiveTrigger> _activeTriggers;

        private Filter _triggerFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _sprites = World
                .GetStash<Sprite>();
            _activeTriggers = World
                .GetStash<ActiveTrigger>();

            _triggerFilter = World.Filter
                .With<Trigger>()
                .With<Sprite>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var triggerEntity in _triggerFilter)
            {
                ref var sprite = ref _sprites.Get(triggerEntity);

                sprite.Value.enabled = _activeTriggers.Has(triggerEntity);
            }
        }

        public void Dispose()
        {
            _triggerFilter = default;
        }
    }
}