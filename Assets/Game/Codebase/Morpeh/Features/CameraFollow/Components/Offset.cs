using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace Game.Codebase.Morpeh.Features.CameraFollow.Components
{
    [Serializable]
    public struct Offset : IComponent
    {
        public Vector3 Value;
    }
}