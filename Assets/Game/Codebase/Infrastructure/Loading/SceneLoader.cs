using Cysharp.Threading.Tasks;
using System;
using UnityEngine.SceneManagement;

namespace Game.Codebase.Infrastructure.Loading
{
    public class SceneLoader : ISceneLoader
    {
        public async UniTaskVoid Load(string name, Action onLoaded = null)
        {
            await SceneManager.LoadSceneAsync(name).ToUniTask().ContinueWith(() => onLoaded?.Invoke());
        }
    }
}