using Core.Scripts.Globals;
using Core.Scripts.Globals.Managers;
using Core.Scripts.GrabCamera.InputHandler;
using UnityEngine;

namespace Core.Scripts.GrabCamera
{
    public class CameraMover : MonoBehaviour
    {
        #region Statements

        // Components
        private IInputHandler _inputHandler;
        private ICameraController _cameraController;
        
        // World
        private Vector3 _mouseWorldPositionStart;

        private void Awake()
        {
            _inputHandler = GetComponent<IInputHandler>();
            _cameraController = GetComponent<ICameraController>();
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

        #region Functions

        private void SetMouseWorldPositionStart()
        {
            var mousePosition = NewInput.GetMousePosition();
            var mouseWorldRay = _cameraController.Camera.ScreenPointToRay(mousePosition);
            _mouseWorldPositionStart = CameraController.GetRayIntersectionWithYPlane(mouseWorldRay, 0f);
        }
        
        private void Move()
        {
            if (_inputHandler.Move.Equals(Vector2.zero)) return;

            var mousePosition = NewInput.GetMousePosition();
            var mouseRay = _cameraController.Camera.ScreenPointToRay(mousePosition);
            var planeY = new Plane(Vector3.up, Vector3.zero);

            if (!planeY.Raycast(mouseRay, out var distance)) return;

            var mouseWorldPosition = mouseRay.GetPoint(distance);
            var mouseWorldPositionDiff = _mouseWorldPositionStart - mouseWorldPosition;
            mouseWorldPositionDiff.y = 0;
            
            var cameraTransform = transform;
            var newPosition = cameraTransform.position + mouseWorldPositionDiff;
            cameraTransform.position = newPosition;

            _cameraController.CheckCameraPositionLimits();
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
            SetMouseWorldPositionStart();
            CursorManager.Instance.SetCursor(CursorManager.CursorState.Grab);
        }

        private void OnLeftClickUp()
        {
            CursorManager.Instance.SetCursor(CursorManager.CursorState.Hand);
        }

        private void OnLeftClickHeld()
        {
            Move();
        }

        #endregion
    }
}
