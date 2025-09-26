using Cysharp.Threading.Tasks;
using System;
using UnityEngine.SceneManagement;

namespace Game.Codebase.Infrastructure.Loading
{
    public class SceneLoader : ISceneLoader
    {
        public async UniTask Load(string name)
        {
            await SceneManager.LoadSceneAsync(name).ToUniTask();
        }
    }
}