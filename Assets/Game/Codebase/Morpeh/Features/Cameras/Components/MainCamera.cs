using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace Game.Codebase.Morpeh.Features.Cameras.Components
{
    [Serializable]
    public struct MainCamera : IComponent
    {
        public Camera Value;
    }
}