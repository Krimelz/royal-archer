using Scellecs.Morpeh;
using System;
using UnityEngine;

namespace Game.Codebase.Morpeh.Features.Movement.Components
{
    [Serializable]
    public struct TurnTowardDirection : IComponent
    {
        public Transform Value;
    }
}