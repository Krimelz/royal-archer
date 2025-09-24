using Cysharp.Threading.Tasks;
using Game.Codebase.Infrastructure.States.StateInfrastructure;
using Game.Codebase.Infrastructure.States.StateMachine;
using UnityEditor;
using UnityEngine;

namespace Game.Codebase.Infrastructure.States.GameStates
{
    public class AppExitState : IState
    {
        private readonly IGameStateMachine _stateMachine;

        public AppExitState(IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            UnityEngine.Application.Quit();
#endif
        }

        public async UniTask Exit()
        {
            await UniTask.CompletedTask;
        }
    }
}
