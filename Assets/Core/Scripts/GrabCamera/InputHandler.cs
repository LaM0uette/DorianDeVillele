using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Scripts.GrabCamera
{
    public class InputHandler : MonoBehaviour
    {
        public delegate void MouseButtonEvent();
        public event MouseButtonEvent OnLeftClickDown;
        public event MouseButtonEvent OnLeftClickUp;
        public event MouseButtonEvent OnLeftClickHold;
        public event MouseButtonEvent OnLeftClickHeld;
        
        private InputActionAsset inputActions;
        private InputAction mouseLeftClickAction;

        private void Awake()
        {
            inputActions = GetComponent<PlayerInput>().actions;
            mouseLeftClickAction = inputActions.FindAction("LeftClick");
        }

        private void OnEnable()
        {
            mouseLeftClickAction.started += HandleLeftClickDown;
            mouseLeftClickAction.canceled += HandleLeftClickUp;
            mouseLeftClickAction.performed += HandleLeftClickHold;
            mouseLeftClickAction.Enable();
        }

        private void OnDisable()
        {
            mouseLeftClickAction.started -= HandleLeftClickDown;
            mouseLeftClickAction.canceled -= HandleLeftClickUp;
            mouseLeftClickAction.performed -= HandleLeftClickHold;
            mouseLeftClickAction.Disable();
        }

        private void HandleLeftClickDown(InputAction.CallbackContext context)
        {
            OnLeftClickDown?.Invoke();
        }

        private void HandleLeftClickUp(InputAction.CallbackContext context)
        {
            OnLeftClickUp?.Invoke();
        }

        private void HandleLeftClickHold(InputAction.CallbackContext context)
        {
            OnLeftClickHold?.Invoke();
        }
        
        private void Update()
        {
            if (mouseLeftClickAction.ReadValue<float>() > 0)
            {
                OnLeftClickHeld?.Invoke();
            }
        }
    }
}
