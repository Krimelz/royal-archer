using Cysharp.Threading.Tasks;
using System;

namespace Game.Codebase.Infrastructure.Loading
{
    public interface ISceneLoader
    {
        UniTask Load(string name);
    }
}