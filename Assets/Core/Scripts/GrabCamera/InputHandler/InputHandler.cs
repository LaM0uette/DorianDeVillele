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
        public Vector2 Move { get; private set; }
        
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

        private void HandleLeftClickHeld()
        {
            if (!(_leftClickAction.ReadValue<float>() > 0)) return;
            OnLeftClickHeld?.Invoke();
        }
        
        private void MoveInput(Vector2 input) => Move = input;

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
        
        public void OnMove(InputValue value) => MoveInput(value.Get<Vector2>());

        private void Update()
        {
            HandleLeftClickHeld();
        }

        #endregion
    }
}
