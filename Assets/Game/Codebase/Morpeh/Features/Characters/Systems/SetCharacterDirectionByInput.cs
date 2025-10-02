using Game.Codebase.Morpeh.Features.Characters.Components;
using Game.Codebase.Morpeh.Features.Movement.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Elysium;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using Input = Game.Codebase.Morpeh.Features.Inputs.Components.Input;
using InputAxis = Game.Codebase.Morpeh.Features.Inputs.Components.InputAxis;

namespace Game.Codebase.Morpeh.Features.Characters.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class SetCharacterDirectionByInput : IUpdateSystem
    {
        private Stash<InputAxis> _inputAxises;
        private Stash<MovementDirection> _directions;
        
        private Filter _inputFilter;
        private Filter _characterFilter;
        
        public World World { get; set; }
        
        public void OnAwake()
        {
            _inputAxises = World.GetStash<InputAxis>();
            _directions = World.GetStash<MovementDirection>();

            _inputFilter = World.Filter
                .With<Input>()
                .With<InputAxis>()
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
                    ref var axis = ref _inputAxises.Get(inputEntity);
                    
                    _directions.Set(characterEntity, new MovementDirection
                    {
                        Value = new Vector3(axis.Value.x, 0f, axis.Value.y).normalized,
                    });
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