using Scellecs.Morpeh;
using System;
using UnityEngine;

namespace Game.Codebase.Morpeh.Features.Common.Components
{
    [Serializable]
    public struct Sprite : IComponent
    {
        public SpriteRenderer Value;
    }
}