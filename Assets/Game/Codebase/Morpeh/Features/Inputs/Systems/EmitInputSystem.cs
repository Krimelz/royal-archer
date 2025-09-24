using Game.Codebase.Infrastructure.Inputs;
using Game.Codebase.Morpeh.Features.Inputs.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Elysium;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using Input = Game.Codebase.Morpeh.Features.Inputs.Components.Input;

namespace Game.Codebase.Morpeh.Features.Inputs.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class EmitInputSystem : IUpdateSystem
    {
        private Stash<InputAxis> _inputAxises;
        private Stash<InputMove> _inputMoves;
        private Stash<InputEscape> _inputEscapes;

        private Filter _filter;

        private IInputService _inputService;

        public EmitInputSystem(IInputService inputService)
        {
            _inputService = inputService;
        }

        public World World { get; set; }

        public void OnAwake()
        {
            _inputAxises = World
                .GetStash<InputAxis>();
            _inputMoves = World
                .GetStash<InputMove>();
            _inputEscapes = World
                .GetStash<InputEscape>();

            _filter = World.Filter
                .With<Input>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            _inputAxises.RemoveAll();
            _inputMoves.RemoveAll();
            _inputEscapes.RemoveAll();

            foreach (var inputEntity in _filter)
            {
                if (_inputService.Axis != Vector2.zero)
                {
                    _inputAxises.Set(inputEntity, new InputAxis
                    {
                        Value = _inputService.Axis
                    });
                }

                if (_inputService.Move)
                {
                    _inputMoves.Set(inputEntity, new InputMove());
                }

                if (_inputService.Escape)
                {
                    _inputEscapes.Set(inputEntity, new InputEscape());
                }
            }
        }

        public void Dispose()
        {
            _filter = null;
        }
    }
}