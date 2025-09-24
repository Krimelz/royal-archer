using Game.Codebase.Morpeh.Common;
using Game.Codebase.Morpeh.Common.Physics;
using Game.Codebase.Morpeh.Features.Characters.Components;
using Game.Codebase.Morpeh.Features.Common.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace Game.Codebase.Morpeh.Features.Triggers.Systems
{
    public class ActivateTriggerSystem : IFixedSystem
    {
        private Stash<ActiveTrigger> _triggers;
        private Stash<Position> _positions;

        private Filter _characterFilter;

        private readonly IPhysicsService _physics;
        private readonly int _layer = 1 << LayerMask.NameToLayer("Trigger");
        private readonly float _radius = 1f;

        public ActivateTriggerSystem(IPhysicsService physicsService)
        {
            _physics = physicsService;
        }

        public World World { get; set; }

        public void OnAwake()
        {
            _triggers = World
                .GetStash<ActiveTrigger>();
            _positions = World
                .GetStash<Position>();

            _characterFilter = World.Filter
                .With<Character>()
                .With<Position>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var characterEntity in _characterFilter)
            {
                ref var position = ref _positions.Get(characterEntity);

                if (_physics.TrySphereOverlap(position.Value, _radius, _layer, out var triggerEntity))
                {
                    _triggers.Set(triggerEntity, new ActiveTrigger());
                }
            }
        }

        public void Dispose()
        {
            _characterFilter = default;
        }
    }
}