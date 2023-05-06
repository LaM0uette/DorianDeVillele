using UnityEngine;

namespace Core.Scripts.GrabCamera.InputHandler
{
    public interface IInputHandler
    {
        event System.Action OnLeftClickDown;
        event System.Action OnLeftClickUp;
        event System.Action OnLeftClickHeld;
        
        Vector2 Move { get; }
    }
}
