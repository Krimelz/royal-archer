using Scellecs.Morpeh;
using Game.Codebase.Morpeh.Features.Inputs;
using Input = Game.Codebase.Morpeh.Features.Inputs.Components.Input;
using Game.Codebase.Infrastructure.States.StateMachine;
using Game.Codebase.Infrastructure.States.GameStates;
using Game.Codebase.Morpeh.Features.Inputs.Components;
using Game.Codebase.Morpeh.Features.Triggers.Components;
using Scellecs.Morpeh.Elysium;
using Unity.IL2CPP.CompilerServices;

namespace Game.Codebase.Morpeh.Features.Triggers.Systems
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public class InteractWithTriggerSystem : IUpdateSystem
    {
        private Stash<Trigger> _triggers;

        private Filter _inputFilter;
        private Filter _activeTriggerFilter;

        private IGameStateMachine _stateMachine;

        public InteractWithTriggerSystem(IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public World World { get; set; }

        public void OnAwake()
        {
            _triggers = World
                .GetStash<Trigger>();

            _inputFilter = World.Filter
                .With<Input>()
                .With<InputAction>()
                .Build();
            _activeTriggerFilter = World.Filter
                .With<Trigger>()
                .With<ActiveTrigger>()
                .Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var inputEntity in _inputFilter)
            {
                foreach (var activeTriggerEntity in _activeTriggerFilter)
                {
                    ref var trigger = ref _triggers.Get(activeTriggerEntity);

                    switch (trigger.Type)
                    {
                        case TriggerType.Transition:
                            UnityEngine.Debug.Log($"Transition trigger {activeTriggerEntity.Id} activated!");
                            _stateMachine.Enter<MenuLoopState>();
                            break;
                        case TriggerType.Item:
                            UnityEngine.Debug.Log($"Item trigger {activeTriggerEntity.Id} activated!");
                            break;
                    }
                }
            }
        }

        public void Dispose()
        {
            _inputFilter = default;
            _activeTriggerFilter = default;
        }
    }
}