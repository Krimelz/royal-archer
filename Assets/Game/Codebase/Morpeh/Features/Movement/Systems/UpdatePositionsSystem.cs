using Game.Codebase.Morpeh.Features.Common.Components;
using Game.Codebase.Morpeh.Features.Movement.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Elysium;
using Unity.IL2CPP.CompilerServices;

namespace Game.Codebase.Morpeh.Features.Movement.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class UpdatePositionsSystem : IUpdateSystem
    {
        private Stash<Position> _positions;
        private Stash<MovementDirection> _movementDirections;
        private Stash<Speed> _speeds;
        private Stash<Transform> _transforms;

        private Filter _filter;

        public World World { get; set; }

        public void OnAwake()
        {
            _positions = World.GetStash<Position>();
            _movementDirections = World.GetStash<MovementDirection>();
            _speeds = World.GetStash<Speed>();
            _transforms =  World.GetStash<Transform>();

            _filter = World.Filter
                .With<Moveable>()
                .With<Position>()
                .With<MovementDirection>()
                .With<Speed>()
                .With<Transform>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var position = ref _positions.Get(entity);
                ref var direction = ref _movementDirections.Get(entity);
                ref var speed = ref _speeds.Get(entity);
                ref var transform = ref _transforms.Get(entity);

                position.Value += transform.Value.TransformDirection(direction.Value) * speed.Value * deltaTime;
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}
