using System;
using Scellecs.Morpeh;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Game.Codebase.Morpeh.Features.Triggers.Components
{
    [Serializable]
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    public struct Trigger : IComponent
    {
        public TriggerType Type;
        public SpriteRenderer Icon;
        public Collider Collider;
    }
}