using Cysharp.Threading.Tasks;

namespace Game.Codebase.Infrastructure.Fader
{
    public interface IFadeService
    {
        UniTask In();
        UniTask Out();
    }
}
