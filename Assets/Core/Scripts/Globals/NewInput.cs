using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Scripts.Globals
{
    public static class NewInput
    {
        public static Vector2 GetMousePosition()
        {
            return Mouse.current.position.ReadValue();
        }
    }
}
