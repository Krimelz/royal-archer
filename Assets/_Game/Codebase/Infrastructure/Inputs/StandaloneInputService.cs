using UnityEngine;

namespace Game.Codebase.Infrastructure.Inputs
{
    public class StandaloneInputService : IInputService
    {
        public Vector2 Axis => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        public bool Escape => Input.GetKeyDown(KeyCode.Escape);
        public bool Move => Input.GetKeyDown(KeyCode.Space);
    }
}