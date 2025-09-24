using UnityEngine;

namespace Game.Codebase.Infrastructure.Inputs
{
    public interface IInputService
    {
        public float Horizontal { get; }
        public float Vertical { get; }
        public Vector2 Axis { get; }
        public bool Escape { get; }
        public bool Move { get; }
    }
}