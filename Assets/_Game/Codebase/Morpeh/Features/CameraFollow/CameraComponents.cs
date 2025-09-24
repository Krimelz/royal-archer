using Scellecs.Morpeh;
using System;
using UnityEngine;

namespace Game.Codebase.Morpeh.Features.CameraFollow.Components
{
    [Serializable] public struct MainCamera : IComponent { public Camera Value; }
    [Serializable] public struct Offset : IComponent { public Vector3 Value; }
}
