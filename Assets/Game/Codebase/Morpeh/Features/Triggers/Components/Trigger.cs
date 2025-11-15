using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace Game.Codebase.Morpeh.Features.Triggers.Components
{
    [Serializable]
    public struct Trigger : IComponent
    {
        public Collider Collider;
    }
}