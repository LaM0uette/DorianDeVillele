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
        
        private InputActionAsset inputActions;
        private InputAction LeftClickAction;

        private void Awake()
        {
            inputActions = GetComponent<PlayerInput>().actions;
            LeftClickAction = inputActions.FindAction("LeftClick");
        }

        #endregion

        #region Subscriptions

        private void SubscribeLeftClickActions()
        {
            LeftClickAction.started += HandleLeftClickDown;
            LeftClickAction.canceled += HandleLeftClickUp;
            LeftClickAction.Enable();
        }
        
        private void UnsubscribeLeftClickActions()
        {
            LeftClickAction.started -= HandleLeftClickDown;
            LeftClickAction.canceled -= HandleLeftClickUp;
            LeftClickAction.Disable();
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
            if (!(LeftClickAction.ReadValue<float>() > 0)) return;
            
            OnLeftClickHeld?.Invoke();
        }

        #endregion
    }
}
