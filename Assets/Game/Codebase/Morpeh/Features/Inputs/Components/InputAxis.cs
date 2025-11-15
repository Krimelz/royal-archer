using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace Game.Codebase.Morpeh.Features.Inputs.Components
{
    [Serializable]
    public struct InputAxis : IComponent
    {
        public Vector2 Value;
    }
}