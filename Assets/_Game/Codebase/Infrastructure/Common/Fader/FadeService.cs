using Cysharp.Threading.Tasks;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine;

namespace Game.Codebase.Infrastructure.Common.Fader
{
    public class FadeService : MonoBehaviour, IFadeService
    {
        public CanvasGroup Fader;

        public async UniTask In()
        {
            await LMotion.Create(0f, 1f, 1f).BindToAlpha(Fader);
        }

        public async UniTask Out()
        {
            await LMotion.Create(1f, 0f, 1f).BindToAlpha(Fader);
        }
    }
}
