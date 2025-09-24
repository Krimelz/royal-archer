using Cysharp.Threading.Tasks;
using Game.Codebase.Infrastructure.States.StateInfrastructure;
using Game.Codebase.Infrastructure.States.StateMachine;

namespace Game.Codebase.Infrastructure.States.GameStates
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _stateMachine;

        public BootstrapState(IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _stateMachine.Enter<MenuLoopState>();
        }

        public async UniTask Exit()
        {
            await UniTask.CompletedTask;
        }
    }
}