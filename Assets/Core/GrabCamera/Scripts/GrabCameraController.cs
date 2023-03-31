using Core.Globals.Cursors;
using UnityEngine;

namespace Core.GrabCamera.Scripts
{
    public class GrabCameraController : MonoBehaviour
    {
        #region Statements

        [Header("Zoom")]
        [SerializeField] private float zoomForce = 30f;
        [SerializeField] private float zoomMin = 2f;
        [SerializeField] private float zoomMax = 8f;

        // Camera
        private static Vector3 _cameraPositionStart = Vector3.zero;
        private static Quaternion _cameraRotationStart;
        
        // World
        private Camera _camera;
        private Vector3 _cameraPosition;
        private Ray _mouseRay;
        private Vector3 _mouseWorldPositionStart;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Start()
        {
            _cameraPosition = transform.position;
            if (!CheckCameraPositionEqualZero()) SetCameraTransform();
        }
        
        #endregion

        #region Functions
        
        private static bool CheckCameraPositionEqualZero() => _cameraPositionStart.Equals(Vector3.zero);
        
        private void SetCameraTransform()
        {
            var cameraTransform = _camera.transform;
            cameraTransform.position = _cameraPositionStart;
            cameraTransform.rotation = _cameraRotationStart;
        }

        private void SetMouseWorldPositionStart()
        {
            _mouseRay = _camera.ScreenPointToRay(Input.mousePosition);
            _mouseWorldPositionStart = GetRayIntersectionWithYPlane(_mouseRay, 0f);
        }
        
        private static Vector3 GetRayIntersectionWithYPlane(Ray ray, float y)
        {
            if (ray.direction.y.Equals(0)) return ray.GetPoint(ray.origin.y);

            var t = (y - ray.origin.y) / ray.direction.y;
            return ray.GetPoint(t);
        }

        private static void SetCursor(Texture2D cursor, GlobalCursors.ECursor eCursor = GlobalCursors.ECursor.Hand)
        {
            GlobalCursors.SetHandCursor(cursor, eCursor);
        }
        
        private void Move()
        {
            if (Input.GetAxis("Mouse Y").Equals(0) && Input.GetAxis("Mouse X").Equals(0)) return;
            
            var mouseRay = _camera.ScreenPointToRay(Input.mousePosition);
            var planeY = new Plane(Vector3.up, Vector3.zero);

            if (!planeY.Raycast(mouseRay, out var distance)) return;
            
            var mouseWorldPosition = mouseRay.GetPoint(distance);
            var mouseWorldPositionDiff = _mouseWorldPositionStart - mouseWorldPosition;
                
            mouseWorldPositionDiff.y = 0;
            transform.position += mouseWorldPositionDiff;
        }

        private void CheckZoom()
        {
            var zoomAmount = Input.GetAxis("Mouse ScrollWheel") * zoomForce;
            if (Mathf.Abs(zoomAmount) > 0.01f) Zoom(zoomAmount);
        }

        private void Zoom(float amount)
        {
            _cameraPosition = transform.position;
            transform.Translate(0, 0, amount * zoomForce * Time.deltaTime, Space.Self);
            CheckZoomLimit();
        }

        private void CheckZoomLimit()
        {
            if (transform.position.y <= zoomMin) 
                SetCameraPositionY(zoomMin); 
            else if (transform.position.y >= zoomMax) 
                SetCameraPositionY(zoomMax); 
        }

        private void SetCameraPositionY(float zoom) => transform.position = new Vector3(_cameraPosition.x, zoom, _cameraPosition.z);

        private void SetTransform()
        {
            var cameraTransform = _camera.transform;
            _cameraPositionStart = cameraTransform.position;
            _cameraRotationStart = cameraTransform.rotation;
        }

        #endregion

        #region Events

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                SetMouseWorldPositionStart();
                SetCursor(GlobalCursors.Instance.CursorGrab, GlobalCursors.ECursor.Grab);
            } // Left click
            if (Input.GetMouseButtonUp(0))
            {
                SetCursor(GlobalCursors.Instance.CursorHand);
            } // Release left click
            
            if (Input.GetMouseButton(0)) Move(); // Hold left click

            CheckZoom();
        }
        
        private void OnDestroy()
        {
            SetTransform();
        }

        #endregion
    }
}
