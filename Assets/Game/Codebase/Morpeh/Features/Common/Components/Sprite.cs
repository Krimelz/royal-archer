using Scellecs.Morpeh;
using System;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Game.Codebase.Morpeh.Features.Common.Components
{
    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct Sprite : IComponent
    {
        public SpriteRenderer Value;
    }
}