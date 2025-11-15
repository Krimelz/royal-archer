using Cysharp.Threading.Tasks;
using Game.Codebase.Infrastructure.States.Factory;
using Game.Codebase.Infrastructure.States.GameStates;
using Game.Codebase.Infrastructure.States.StateInfrastructure;
using VContainer.Unity;

namespace Game.Codebase.Infrastructure.States.StateMachine
{
    public class GameStateMachine : IGameStateMachine, IStartable, ITickable, IFixedTickable
    {
        private IExitableState _activeState;
        private readonly IStateFactory _stateFactory;

        public GameStateMachine(IStateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public void Start()
        {
            Enter<BootstrapState>().Forget();
        }

        public void Tick()
        {
            if (_activeState is IUpdateable updateableState)
            {
                updateableState.Update();
            }
        }

        public void FixedTick()
        {
            if (_activeState is IFixedUpdatable fixedUpdatableState)
            {
                fixedUpdatableState.FixedUpdate();
            }
        }

        public async UniTaskVoid Enter<TState>() where TState : class, IState
        {
            IState state = await ChangeState<TState>();
            state.Enter();
        }

        public async UniTaskVoid Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            var state = await ChangeState<TState>();
            state.Enter(payload);
        }

        private async UniTask<TState> ChangeState<TState>() where TState : class, IExitableState
        {
            if (_activeState != null)
            {
                await _activeState.Exit();
            }

            var state = _stateFactory.GetState<TState>();
            _activeState = state;

            return state;
        }
    }
}