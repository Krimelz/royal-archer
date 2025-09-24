using Game.Codebase.Morpeh.Features.Characters.Components;
using Game.Codebase.Morpeh.Features.Inputs;
using Game.Codebase.Morpeh.Features.Movement;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Elysium;
using UnityEngine;
using Input = Game.Codebase.Morpeh.Features.Inputs.Input;

namespace Game.Codebase.Morpeh.Features.Characters.Systems
{
    public class SetCharacterMovementDirectionByInputSystem : IUpdateSystem
    {
        private Stash<InputAxis> _inputAxises;
        private Stash<MovementDirection> _movementDirections;

        private Filter _inputFilter;
        private Filter _characterFilter;

        public World World { get; set; }

        public void OnAwake()
        {
            _inputAxises = World
                .GetStash<InputAxis>();
            _movementDirections = World
                .GetStash<MovementDirection>();

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
                ref var axis = ref _inputAxises.Get(inputEntity, out var exist);

                foreach (var characterEntity in _characterFilter)
                {
                    if (exist)
                    {
                        _movementDirections.Set(characterEntity, new MovementDirection
                        {
                            Value = new Vector3(axis.Value.x, 0f, axis.Value.y)
                        });
                    }
                    else
                    {
                        _movementDirections.Remove(characterEntity);
                    }
                }
            }
        }

        public void Dispose()
        {
            _inputFilter = default;
        }
    }
}