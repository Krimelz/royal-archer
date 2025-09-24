using Game.Codebase.Morpeh.Features.Common.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Elysium;
using Unity.IL2CPP.CompilerServices;

namespace Game.Codebase.Morpeh.Features.Movement.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class SetTransformPositionSystem : IUpdateSystem
    {
        private Stash<Transform> _transfroms;
        private Stash<Position> _positions;

        private Filter _transformsFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _transfroms = World
                .GetStash<Transform>();
            _positions = World
                .GetStash<Position>();

            _transformsFilter = World.Filter
                .With<Transform>()
                .With<Position>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _transformsFilter)
            {
                ref var transform = ref _transfroms.Get(entity);
                ref var position = ref _positions.Get(entity);

                transform.Value.position = position.Value;
            }
        }

        public void Dispose()
        {
            _transformsFilter = default;
        }
    }
}