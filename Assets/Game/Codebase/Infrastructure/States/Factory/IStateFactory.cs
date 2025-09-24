using Game.Codebase.Infrastructure.States.StateInfrastructure;

namespace Game.Codebase.Infrastructure.States.Factory
{
	public interface IStateFactory
	{
		T GetState<T>() where T : class, IExitableState;
	}
}