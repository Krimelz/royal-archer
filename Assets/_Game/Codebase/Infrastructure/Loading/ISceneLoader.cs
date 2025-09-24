using Cysharp.Threading.Tasks;
using System;

namespace Game.Codebase.Infrastructure.Loading
{
    public interface ISceneLoader
    {
        UniTaskVoid Load(string name, Action onLoaded = null);
    }
}