using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Scripts.GrabCamera.InputHandler
{
    public class InputHandler : MonoBehaviour, IInputHandlerEvent, IInputHandlerInputs
    {
        #region Statements

        // Events
        public event Action OnLeftClickDown;
        public event Action OnLeftClickUp;
        public event Action OnLeftClickHeld;
        
        // Inoputs
        public Vector2 Move => _moveAction.ReadValue<Vector2>();
        
        private InputActionAsset _inputActions;
        private InputAction _leftClickAction;
        private InputAction _moveAction;

        private void Awake()
        {
            _inputActions = GetComponent<PlayerInput>().actions;
            InitializeInputActions();
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
        
        private void SubscribeMoveActions()
        {
            _moveAction.Enable();
        }
        private void UnsubscribeMoveActions()
        {
            _moveAction.Disable();
        }

        #endregion

        #region Functions
        
        private void InitializeInputActions()
        {
            _leftClickAction = _inputActions.FindAction("LeftClick");
            _moveAction = _inputActions.FindAction("Move");
        }

        private void HandleLeftClickDown(InputAction.CallbackContext context)
        {
            OnLeftClickDown?.Invoke();
        }

        private void HandleLeftClickUp(InputAction.CallbackContext context)
        {
            OnLeftClickUp?.Invoke();
        }

        private void HandleLeftClickHeld()
        {
            if (!(_leftClickAction.ReadValue<float>() > 0)) return;
            OnLeftClickHeld?.Invoke();
        }

        #endregion

        #region Events

        private void OnEnable()
        {
            SubscribeLeftClickActions();
            SubscribeMoveActions();
        }
        
        private void OnDisable()
        {
            UnsubscribeLeftClickActions();
            UnsubscribeMoveActions();
        }

        private void Update()
        {
            HandleLeftClickHeld();
        }

        #endregion
    }
}
