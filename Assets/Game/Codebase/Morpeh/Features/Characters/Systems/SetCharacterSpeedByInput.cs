using Game.Codebase.Morpeh.Features.Characters.Components;
using Game.Codebase.Morpeh.Features.Inputs.Components;
using Game.Codebase.Morpeh.Features.Movement.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Elysium;
using Unity.IL2CPP.CompilerServices;

namespace Game.Codebase.Morpeh.Features.Characters.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class SetCharacterSpeedByInput : IUpdateSystem
    {
        private Stash<InputAxis> _inputAxises;
        private Stash<Speed> _speeds;
        
        private Filter _inputFilter;
        private Filter _characterFilter;
        
        public World World { get; set; }
        
        public void OnAwake()
        {
            _inputAxises = World.GetStash<InputAxis>();
            _speeds = World.GetStash<Speed>();

            _inputFilter = World.Filter
                .With<Input>()
                .Build();
            _characterFilter = World.Filter
                .With<Character>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var inputEntity in _inputFilter)
            {
                foreach (var characterEntity in _characterFilter)
                {
                    ref var speed = ref _speeds.Get(characterEntity);
                    
                    _inputAxises.Get(inputEntity, out var exist);
                    
                    speed.Value = exist ? 1f : 0f;
                }
            }
        }
        
        public void Dispose()
        {
            _inputFilter = null;
            _characterFilter = null;
        }
    }
}