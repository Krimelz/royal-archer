using Cysharp.Threading.Tasks;

namespace Game.Codebase.Infrastructure.States.StateInfrastructure
{
	public interface IExitableState
	{
		UniTask Exit();
	}
}