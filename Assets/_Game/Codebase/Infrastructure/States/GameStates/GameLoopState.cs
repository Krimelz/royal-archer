using Cysharp.Threading.Tasks;
using Game.Codebase.Infrastructure.Common.Fader;
using Game.Codebase.Infrastructure.Loading;
using Game.Codebase.Infrastructure.States.StateInfrastructure;
using Game.Codebase.Morpeh.Features.Characters;
using Game.Codebase.Morpeh.Features.Destroy;
using Game.Codebase.Morpeh.Features.Inputs;
using Game.Codebase.Morpeh.Features.Movement;
using Game.Codebase.Morpeh.Features.Triggers;
using Scellecs.Morpeh.Elysium;
using UnityEngine;
using VContainer.Unity;

namespace Game.Codebase.Infrastructure.States.GameStates
{
    public class GameLoopState : IState, IUpdateable
    {
        private const string GAME_SCENE = "Game";

        private readonly ISceneLoader _sceneLoader;
        private readonly IFadeService _fadeService;
        private readonly LifetimeScope _scope;

        private EcsStartup _startup;

        public GameLoopState(LifetimeScope scope, ISceneLoader sceneLoader, IFadeService fadeService)
        {
            _scope = scope;
            _fadeService = fadeService;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(GAME_SCENE, () =>
            {
                _startup = new EcsStartup(new VContainerResolver(_scope));

                _startup
                    .AddSystemsGroup()
                    .AddFeatureInjected<InputFeature>()
                    .AddFeatureInjected<TriggerFeature>()
                    .AddFeatureInjected<CharacterFeature>()
                    .AddFeatureInjected<MovementFeature>()
                    .AddFeatureInjected<DestroyFeature>()
                    ;

                _startup.Initialize(false);

                _fadeService.Out();
            });
        }

        public void Update()
        {
            _startup?.Update(Time.deltaTime);
        }

        public async UniTask Exit()
        {
            await UniTask.WaitForEndOfFrame();

            _startup?.LateUpdate(Time.deltaTime);
            _startup?.DisconnectWorld();

            await _fadeService.In();
        }
    }
}