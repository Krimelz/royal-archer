using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace Game.Codebase.Morpeh.Features.CameraFollow.Components
{
    [Serializable]
    public struct MainCamera : IComponent
    {
        public Camera Value;
    }
}