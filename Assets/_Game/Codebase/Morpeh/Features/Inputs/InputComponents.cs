using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace Game.Codebase.Morpeh.Features.Inputs
{
    [Serializable] public struct Input : IComponent { }
    [Serializable] public struct InputAxis : IComponent { public Vector2 Value; }
    [Serializable] public struct InputEscape : IComponent { }
    [Serializable] public struct InputMove : IComponent { }
}
