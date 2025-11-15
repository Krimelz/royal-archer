using Scellecs.Morpeh;
using System;

namespace Game.Codebase.Morpeh.Features.Common.Components
{
    [Serializable]
    public struct Rigidbody : IComponent
    {
        public UnityEngine.Rigidbody Value;
    }
}
