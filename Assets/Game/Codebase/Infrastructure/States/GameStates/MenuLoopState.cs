using Cysharp.Threading.Tasks;
using Game.Codebase.Infrastructure.Common.Fader;
using Game.Codebase.Infrastructure.Loading;
using Game.Codebase.Infrastructure.States.StateInfrastructure;

namespace Game.Codebase.Infrastructure.States.GameStates
{
    public class MenuLoopState : IState
    {
        private const string MENU_SCENE = "Menu";

        private readonly ISceneLoader _sceneLoader;
        private readonly IFadeService _fadeService;

        public MenuLoopState(ISceneLoader sceneLoader, IFadeService fadeService)
        {
            _sceneLoader = sceneLoader;
            _fadeService = fadeService;
        }

        public async void Enter()
        {
            await _sceneLoader.Load(MENU_SCENE);
            await _fadeService.Out();
        }

        public async UniTask Exit()
        {
            await _fadeService.In();
        }
    }
}