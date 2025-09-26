using Game.Codebase.Infrastructure.States.GameStates;
using Game.Codebase.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Game.Codebase.Behaviours.Ui
{
    public class MenuScreen : MonoBehaviour
    {
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _creditsButton;
        [SerializeField] private Button _exitButton;

        [Inject] private readonly IGameStateMachine _stateMachine;
        
        private void OnEnable()
        {
            _continueButton.onClick.AddListener(() => _stateMachine.Enter<GameLoopState>());
            _startButton.onClick.AddListener(() => _stateMachine.Enter<GameLoopState>());
            _settingsButton.onClick.AddListener(() => { });
            _creditsButton.onClick.AddListener(() => { });
            _exitButton.onClick.AddListener(() => _stateMachine.Enter<AppExitState>());
        }

        private void OnDisable()
        {
            _continueButton.onClick.RemoveAllListeners();
            _startButton.onClick.RemoveAllListeners();
            _settingsButton.onClick.RemoveAllListeners();
            _creditsButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
        }
    }
}
