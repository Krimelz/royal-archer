using Cysharp.Threading.Tasks;
using Game.Codebase.Infrastructure.States.StateInfrastructure;

namespace Game.Codebase.Infrastructure.States.StateMachine
{
	public interface IGameStateMachine
	{
		UniTaskVoid Enter<TState>() where TState : class, IState;
		UniTaskVoid Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
	}
}