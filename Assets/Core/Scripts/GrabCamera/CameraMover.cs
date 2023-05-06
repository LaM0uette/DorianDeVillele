using Core.Scripts.Globals;
using Core.Scripts.GrabCamera.InputHandler;
using UnityEngine;

namespace Core.Scripts.GrabCamera
{
    public class CameraMover : MonoBehaviour
    {
        #region Statements

        // Components
        private IInputHandler _inputHandler;
        private Camera _camera;
        
        // World
        private Vector3 _mouseWorldPositionStart;

        private void Awake()
        {
            _inputHandler = GetComponent<IInputHandler>();
            _camera = Camera.main;
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
            var mouseWorldRay = _camera.ScreenPointToRay(mousePosition);
            _mouseWorldPositionStart = GetRayIntersectionWithYPlane(mouseWorldRay, 0f);
        }

        private static Vector3 GetRayIntersectionWithYPlane(Ray ray, float y)
        {
            if (ray.direction.y.Equals(0)) return ray.GetPoint(ray.origin.y);
            var t = (y - ray.origin.y) / ray.direction.y;
            return ray.GetPoint(t);
        }
        
        private void Move()
        {
            if (_inputHandler.Move.Equals(Vector2.zero)) return;
            
            var mousePosition = NewInput.GetMousePosition();
            var mouseRay = _camera.ScreenPointToRay(mousePosition);
            var planeY = new Plane(Vector3.up, Vector3.zero);

            if (!planeY.Raycast(mouseRay, out var distance)) return;
            
            var mouseWorldPosition = mouseRay.GetPoint(distance);
            var mouseWorldPositionDiff = _mouseWorldPositionStart - mouseWorldPosition;
                
            mouseWorldPositionDiff.y = 0;
            transform.position += mouseWorldPositionDiff;
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
        }

        private void OnLeftClickUp()
        {
            Debug.Log("CheckLeftClickUp");
        }

        private void OnLeftClickHeld()
        {
            Move();
        }

        #endregion
    }
}
