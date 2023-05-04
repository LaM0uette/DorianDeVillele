using UnityEngine;

namespace Core.Scripts.GrabCamera
{
    public class GrabCameraActions : MonoBehaviour
    {
        private InputHandler inputHandler;

        private void Awake()
        {
            inputHandler = GetComponent<InputHandler>();
        }

        private void OnEnable()
        {
            inputHandler.OnLeftClickDown += CheckLeftClickDown;
            inputHandler.OnLeftClickUp += CheckLeftClickUp;
            inputHandler.OnLeftClickHold += CheckLeftClickHold;
            inputHandler.OnLeftClickHeld += CheckLeftClickHeld;
        }

        private void OnDisable()
        {
            inputHandler.OnLeftClickDown -= CheckLeftClickDown;
            inputHandler.OnLeftClickUp -= CheckLeftClickUp;
            inputHandler.OnLeftClickHold -= CheckLeftClickHold;
            inputHandler.OnLeftClickHeld -= CheckLeftClickHeld;
        }

        private void CheckLeftClickDown()
        {
        Debug.Log("CheckLeftClickDown");
        }

        private void CheckLeftClickUp()
        {
        Debug.Log("CheckLeftClickUp");
        }

        private void CheckLeftClickHold()
        {
        Debug.Log("CheckLeftClickHold");
        }

        private void CheckLeftClickHeld()
        {
            Debug.Log("CheckLeftClickHeld");
        }

    }
}
