using Game.Codebase.Morpeh.Features.Characters.Components;
using Game.Codebase.Morpeh.Features.Inputs.Components;
using Game.Codebase.Morpeh.Features.Movement.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Elysium;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using Input = Game.Codebase.Morpeh.Features.Inputs.Components.Input;

namespace Game.Codebase.Morpeh.Features.Characters.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class SetCharacterBowDirectionByInputSystem : IUpdateSystem
    {
        private Stash<Character> _characters;
        private Stash<InputAxis> _inputAxises;

        private Filter _inputFilter;
        private Filter _characterFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _characters = World.GetStash<Character>();
            _inputAxises = World.GetStash<InputAxis>();

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
                    ref var axis = ref _inputAxises.Get(inputEntity, out var exist);
                    ref var character = ref _characters.Get(characterEntity);
                    
                    character.Bow.transform.Rotate(new Vector3(0, 0, axis.Value.y * deltaTime * 5f));
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