using Core.Scripts.Globals;
using Core.Scripts.Globals.Managers;
using Core.Scripts.GrabCamera.InputHandler;
using UnityEngine;

namespace Core.Scripts.GrabCamera
{
    public class CameraMover : MonoBehaviour
    {
        #region Statements
        
        // Limits
        [Header("Limits")]
        [SerializeField] private GameObject _limitMin;
        [SerializeField] private GameObject _limitMax;

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
        
        private void SubscribeCameraZoomer(CameraZoomer cameraZoomer)
        {
            cameraZoomer.OnZoomLimitsChecked += CheckPositionLimits;
        }
        private void UnsubscribeCameraZoomer(CameraZoomer cameraZoomer)
        {
            cameraZoomer.OnZoomLimitsChecked -= CheckPositionLimits;
        }

        #endregion

        #region Functions

        private void SetMouseWorldPositionStart()
        {
            var mousePosition = NewInput.GetMousePosition();
            var mouseWorldRay = _camera.ScreenPointToRay(mousePosition);
            _mouseWorldPositionStart = GetRayIntersectionWithYPlane(mouseWorldRay, 0f);
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
            
            var cameraTransform = transform;
            var newPosition = cameraTransform.position + mouseWorldPositionDiff;
            cameraTransform.position = newPosition;

            CheckPositionLimits();
        }
        
        private void CheckPositionLimits()
        {
            var position = transform.position;
            var viewportCenter = new Vector3(0.5f, 0.5f, 0);
            var ray = _camera.ViewportPointToRay(viewportCenter);
            var intersectionPoint = GetRayIntersectionWithYPlane(ray, 0);
            var offset = intersectionPoint - position;
            offset.y = 0;

            var newViewportCenter = position + offset;
            var limitMin = _limitMin.transform.position;
            var limitMax = _limitMax.transform.position;

            newViewportCenter.x = Mathf.Clamp(newViewportCenter.x, limitMin.x, limitMax.x);
            newViewportCenter.z = Mathf.Clamp(newViewportCenter.z, limitMin.z, limitMax.z);

            position = newViewportCenter - offset;
            transform.position = position;
        }
        
        private static Vector3 GetRayIntersectionWithYPlane(Ray ray, float y)
        {
            if (ray.direction.y.Equals(0)) return ray.GetPoint(ray.origin.y);
            var t = (y - ray.origin.y) / ray.direction.y;
            return ray.GetPoint(t);
        }

        #endregion

        #region Events

        private void OnEnable()
        {
            SubscribeInputHandler();
            SubscribeCameraZoomer(GetComponent<CameraZoomer>());
        }

        private void OnDisable()
        {
            UnsubscribeInputHandler();
            UnsubscribeCameraZoomer(GetComponent<CameraZoomer>());
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
