using UnityEngine;

namespace Game.Codebase.Infrastructure.Inputs
{
    public class StandaloneInputService : IInputService
    {
        public float Horizontal => Input.GetAxisRaw("Horizontal");
        public float Vertical => Input.GetAxisRaw("Vertical");
        
        public Vector2 Axis => new(Horizontal, Vertical);
        public bool Escape => Input.GetKeyDown(KeyCode.Escape);
        public bool Move => Input.GetKeyDown(KeyCode.Space);
        public bool Action => Input.GetKeyDown(KeyCode.E);
        public Vector2 Pointer => Input.mousePosition;
    }
}