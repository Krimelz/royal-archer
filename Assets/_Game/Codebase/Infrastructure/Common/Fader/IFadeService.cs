using Cysharp.Threading.Tasks;

namespace Game.Codebase.Infrastructure.Common.Fader
{
    public interface IFadeService
    {
        UniTask In();
        UniTask Out();
    }
}
