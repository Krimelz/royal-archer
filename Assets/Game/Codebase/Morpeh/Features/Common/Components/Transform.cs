using Scellecs.Morpeh;
using System;

namespace Game.Codebase.Morpeh.Features.Common.Components
{
    [Serializable]
    public struct Transform : IComponent
    {
        public UnityEngine.Transform Value;
    }
}