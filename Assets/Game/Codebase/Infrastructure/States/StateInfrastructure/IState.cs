namespace Game.Codebase.Infrastructure.States.StateInfrastructure
{
	public interface IState : IExitableState
	{
		void Enter();
	}
}