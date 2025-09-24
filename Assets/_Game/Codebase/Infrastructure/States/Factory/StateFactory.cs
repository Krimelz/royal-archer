using Game.Codebase.Infrastructure.States.StateInfrastructure;
using VContainer;
using VContainer.Unity;

namespace Game.Codebase.Infrastructure.States.Factory
{
	public class StateFactory : IStateFactory
	{
		private readonly LifetimeScope _scope;

		public StateFactory(LifetimeScope scope)
		{
			_scope = scope;
		}

		public T GetState<T>() where T : class, IExitableState
		{
			return _scope.Container.Resolve<T>();
		}
	}
}