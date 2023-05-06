namespace Core.Scripts.GrabCamera.InputHandler
{
    public interface IInputHandlerEvent
    {
        event System.Action OnLeftClickDown;
        event System.Action OnLeftClickUp;
        event System.Action OnLeftClickHeld;
    }
}
