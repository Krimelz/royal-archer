using Game.Codebase.Morpeh.Features.CameraFollow.Components;
using Game.Codebase.Morpeh.Features.Characters.Components;
using Game.Codebase.Morpeh.Features.Common.Components;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;

namespace Game.Codebase.Morpeh.Features.CameraFollow.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class CameraLookSystem : ILateSystem
    {
        private Stash<MainCamera> _cameras;
        private Stash<Position> _positions;

        private Filter _cameraFilter;
        private Filter _characterFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _cameras = World
                .GetStash<MainCamera>();
            _positions = World
                .GetStash<Position>();

            _cameraFilter = World.Filter
                .With<MainCamera>()
                .Build();
            _characterFilter = World.Filter
                .With<Character>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var cameraEntity in _cameraFilter)
            {
                ref var camera = ref _cameras.Get(cameraEntity);

                foreach (var characterEntity in _characterFilter)
                {
                    ref var characterPosition = ref _positions.Get(characterEntity);

                    camera.Value.transform.LookAt(characterPosition.Value);
                }
            }
        }

        public void Dispose()
        {
            _cameraFilter = null;
            _characterFilter = null;
        }
    }
}
