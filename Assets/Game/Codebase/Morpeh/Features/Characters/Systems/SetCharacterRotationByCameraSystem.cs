using Game.Codebase.Morpeh.Features.Cameras.Components;
using Game.Codebase.Morpeh.Features.Characters.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Elysium;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using Transform = Game.Codebase.Morpeh.Features.Common.Components.Transform;

namespace Game.Codebase.Morpeh.Features.Characters.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class SetCharacterRotationByCameraSystem : IUpdateSystem
    {
        private Stash<MainCamera> _cameras;
        private Stash<Transform> _transforms;

        private Filter _cameraFilter;
        private Filter _characterFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _cameras = World.GetStash<MainCamera>();
            _transforms = World.GetStash<Transform>();

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
                foreach (var characterEntity in _characterFilter)
                {
                    ref var camera = ref _cameras.Get(cameraEntity);
                    ref var characterTransform = ref _transforms.Get(characterEntity);
                    
                    characterTransform.Value.eulerAngles = new Vector3(0f, camera.Value.transform.eulerAngles.y, 0f);
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