using Scellecs.Morpeh;
using System;
using UnityEngine;

namespace Game.Codebase.Morpeh.Features.Common.Components
{
    [Serializable]
    public struct Position : IComponent
    {
        public Vector3 Value;
    }
}