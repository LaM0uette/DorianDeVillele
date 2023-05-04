using UnityEngine;

namespace Core.Scripts.GrabCamera
{
    public class GrabCameraActions : MonoBehaviour
    {
        #region Statements

        private InputHandler inputHandler;

        private void Awake()
        {
            inputHandler = GetComponent<InputHandler>();
        }

        #endregion
        
        #region Subscriptions

        private void SubscribeInputHandler()
        {
            inputHandler.OnLeftClickDown += OnLeftClickDown;
            inputHandler.OnLeftClickUp += OnLeftClickUp;
            inputHandler.OnLeftClickHeld += OnLeftClickHeld;
        }
        
        private void UnsubscribeInputHandler()
        {
            inputHandler.OnLeftClickDown -= OnLeftClickDown;
            inputHandler.OnLeftClickUp -= OnLeftClickUp;
            inputHandler.OnLeftClickHeld -= OnLeftClickHeld;
        }

        #endregion

        #region Events

        private void OnEnable()
        {
            SubscribeInputHandler();
        }

        private void OnDisable()
        {
            UnsubscribeInputHandler();
        }

        private void OnLeftClickDown()
        {
            Debug.Log("CheckLeftClickDown");
        }

        private void OnLeftClickUp()
        {
            Debug.Log("CheckLeftClickUp");
        }

        private void OnLeftClickHeld()
        {
            Debug.Log("CheckLeftClickHeld");
        }

        #endregion
    }
}
