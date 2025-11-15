using Game.Codebase.Morpeh.Features.Common.Components;
using Game.Codebase.Morpeh.Features.Movement.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Game.Codebase.Morpeh.Features.Common.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    class SetRigidbodyVelocitySystem : IFixedSystem
    {
        private Stash<Rigidbody> _rigidbodies;
        private Stash<Speed> _speeds;
        private Stash<MovementDirection> _movementDirections;

        private Filter _filter;

        public World World { get; set; }

        public void OnAwake()
        {
            _rigidbodies = World.GetStash<Rigidbody>();
            _speeds = World.GetStash<Speed>();
            _movementDirections = World.GetStash<MovementDirection>();

            _filter = World.Filter
                .With<Rigidbody>()
                .With<Speed>()
                .With<MovementDirection>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                ref var rigidbody = ref _rigidbodies.Get(entity);
                ref var speed = ref _speeds.Get(entity);
                ref var direction = ref _movementDirections.Get(entity);

                rigidbody.Value.linearVelocity = rigidbody.Value.transform.TransformDirection(speed.Value * direction.Value);
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}
