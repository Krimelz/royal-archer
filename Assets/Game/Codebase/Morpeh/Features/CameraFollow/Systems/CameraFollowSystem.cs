using Game.Codebase.Morpeh.Features.CameraFollow.Components;
using Game.Codebase.Morpeh.Features.Characters;
using Game.Codebase.Morpeh.Features.Characters.Components;
using Game.Codebase.Morpeh.Features.Common.Components;
using Scellecs.Morpeh;

namespace Game.Codebase.Morpeh.Features.CameraFollow.Systems
{
    public class CameraFollowSystem : ILateSystem
    {
        private Stash<MainCamera> _cameras;
        private Stash<Position> _positions;
        private Stash<Offset> _offsets;

        private Filter _cameraFilter;
        private Filter _characterFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _cameras = World
                .GetStash<MainCamera>();
            _positions = World
                .GetStash<Position>();
            _offsets = World
                .GetStash<Offset>();

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
                ref var cameraOffset = ref _offsets.Get(cameraEntity);

                foreach (var characterEntity in _characterFilter)
                {
                    ref var characterPosition = ref _positions.Get(characterEntity);

                    camera.Value.transform.position = characterPosition.Value + cameraOffset.Value;
                    camera.Value.transform.LookAt(characterPosition.Value);
                }
            }
        }

        public void Dispose()
        {
            _cameraFilter = default;
            _characterFilter = default;
        }
    }
}
