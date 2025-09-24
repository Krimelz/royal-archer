using UnityEngine;

namespace Game.Codebase.Infrastructure.Inputs
{
    public class StandaloneInputService : IInputService
    {
        public float Horizontal => Input.GetAxis("Horizontal");
        public float Vertical => Input.GetAxis("Vertical");
        
        public Vector2 Axis => new(Horizontal, Vertical);
        public bool Escape => Input.GetKeyDown(KeyCode.Escape);
        public bool Move => Input.GetKeyDown(KeyCode.Space);
    }
}