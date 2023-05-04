using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Scripts.GrabCamera
{
    public class InputHandler : MonoBehaviour
    {
        #region Statements

        public delegate void MouseButtonEvent();
        public event MouseButtonEvent OnLeftClickDown;
        public event MouseButtonEvent OnLeftClickUp;
        public event MouseButtonEvent OnLeftClickHeld;
        
        private InputActionAsset _inputActions;
        private InputAction _leftClickAction;

        private void Awake()
        {
            _inputActions = GetComponent<PlayerInput>().actions;
            _leftClickAction = _inputActions.FindAction("LeftClick");
        }

        #endregion

        #region Subscriptions

        private void SubscribeLeftClickActions()
        {
            _leftClickAction.started += HandleLeftClickDown;
            _leftClickAction.canceled += HandleLeftClickUp;
            _leftClickAction.Enable();
        }
        
        private void UnsubscribeLeftClickActions()
        {
            _leftClickAction.started -= HandleLeftClickDown;
            _leftClickAction.canceled -= HandleLeftClickUp;
            _leftClickAction.Disable();
        }

        #endregion

        #region Functions

        private void HandleLeftClickDown(InputAction.CallbackContext context)
        {
            OnLeftClickDown?.Invoke();
        }

        private void HandleLeftClickUp(InputAction.CallbackContext context)
        {
            OnLeftClickUp?.Invoke();
        }

        #endregion

        #region Events

        private void OnEnable()
        {
            SubscribeLeftClickActions();
        }

        private void OnDisable()
        {
            UnsubscribeLeftClickActions();
        }
        
        private void Update()
        {
            if (!(_leftClickAction.ReadValue<float>() > 0)) return;
            
            OnLeftClickHeld?.Invoke();
        }

        #endregion
    }
}
