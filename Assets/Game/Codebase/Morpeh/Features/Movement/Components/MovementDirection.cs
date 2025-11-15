using Scellecs.Morpeh;
using System;
using UnityEngine;

namespace Game.Codebase.Morpeh.Features.Movement.Components
{
    [Serializable]
    public struct MovementDirection : IComponent
    {
        public Vector3 Value;
    }
}