using Game.Codebase.Infrastructure.Common.Collisions;
using Game.Codebase.Infrastructure.Common.Fader;
using Game.Codebase.Infrastructure.Common.Physics;
using Game.Codebase.Infrastructure.Inputs;
using Game.Codebase.Infrastructure.Loading;
using Game.Codebase.Infrastructure.States.Factory;
using Game.Codebase.Infrastructure.States.GameStates;
using Game.Codebase.Infrastructure.States.StateMachine;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Codebase.Infrastructure.Scopes
{
    public class BootLifetimeScope : LifetimeScope
    {
        [SerializeField] private FadeService _fader;
        
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterInputService(builder);
            RegisterCommonServices(builder);
            RegisterStateMachine(builder);
            RegisterStateFactory(builder);
            RegisterGameStates(builder);
        }

        protected override void Awake()
        {
            base.Awake();

            Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
        }

        private void RegisterInputService(IContainerBuilder builder)
        {
            builder.Register<IInputService, StandaloneInputService>(Lifetime.Singleton);
        }

        private void RegisterCommonServices(IContainerBuilder builder)
        {
            builder.Register<ICollisionRegistry, CollisionRegistry>(Lifetime.Singleton);
            builder.Register<IPhysicsService, PhysicsService>(Lifetime.Singleton);
            builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
            builder.RegisterComponentInNewPrefab(_fader, Lifetime.Singleton).DontDestroyOnLoad().As<IFadeService>();
        }

        private void RegisterStateMachine(IContainerBuilder builder)
        {
            builder.Register<IGameStateMachine, GameStateMachine>(Lifetime.Singleton);
        }

        private void RegisterStateFactory(IContainerBuilder builder)
        {
            builder.Register<IStateFactory, StateFactory>(Lifetime.Singleton);
        }

        private void RegisterGameStates(IContainerBuilder builder)
        {
            builder.Register<BootstrapState>(Lifetime.Singleton);
            builder.Register<GameLoopState>(Lifetime.Singleton);
            builder.Register<MenuLoopState>(Lifetime.Singleton);
        }
    }
}