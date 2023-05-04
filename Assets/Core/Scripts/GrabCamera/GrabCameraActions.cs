using UnityEngine;

namespace Core.Scripts.GrabCamera
{
    public class GrabCameraActions : MonoBehaviour
    {
        #region Statements

        private InputHandler _inputHandler;

        private void Awake()
        {
            _inputHandler = GetComponent<InputHandler>();
        }

        #endregion
        
        #region Subscriptions

        private void SubscribeInputHandler()
        {
            _inputHandler.OnLeftClickDown += OnLeftClickDown;
            _inputHandler.OnLeftClickUp += OnLeftClickUp;
            _inputHandler.OnLeftClickHeld += OnLeftClickHeld;
        }
        
        private void UnsubscribeInputHandler()
        {
            _inputHandler.OnLeftClickDown -= OnLeftClickDown;
            _inputHandler.OnLeftClickUp -= OnLeftClickUp;
            _inputHandler.OnLeftClickHeld -= OnLeftClickHeld;
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
