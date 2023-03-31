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
        private static Vector3 _cameraPosition = Vector3.zero;
        private static Quaternion _cameraRotation;
        
        // World
        private Camera _camera;
        private Ray _mouseRay;
        private Vector3 _mouseWorldPositionStart;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Start()
        {
            if (!CheckCameraPositionEqualZero()) SetCameraTransform();
        }
        
        #endregion

        #region Functions
        
        private static bool CheckCameraPositionEqualZero() => _cameraPosition.Equals(Vector3.zero);
        
        private void SetCameraTransform()
        {
            var cameraTransform = _camera.transform;
            cameraTransform.position = _cameraPosition;
            cameraTransform.rotation = _cameraRotation;
        }

        private void SetMouseWorldPositionStart()
        {
            _mouseRay = _camera.ScreenPointToRay(Input.mousePosition);
            _mouseWorldPositionStart = GetRayIntersectionWithYPlane(_mouseRay, 0f);
        }
        
        private static Vector3 GetRayIntersectionWithYPlane(Ray ray, float y)
        {
            if (ray.direction.y == 0)
            {
                return ray.GetPoint(ray.origin.y);
            }

            float t = (y - ray.origin.y) / ray.direction.y;
            return ray.GetPoint(t);
        }

        private static void SetCursor(Texture2D cursor, GlobalCursors.ECursor eCursor = GlobalCursors.ECursor.Hand)
        {
            GlobalCursors.SetHandCursor(cursor, eCursor);
        }
        
        private void Move()
        {
            if (!Input.GetAxis("Mouse Y").Equals(0) || !Input.GetAxis("Mouse X").Equals(0))
            {
                var mouseRay = _camera.ScreenPointToRay(Input.mousePosition);
                var planeY = new Plane(Vector3.up, Vector3.zero);
            
                if (planeY.Raycast(mouseRay, out var distance))
                {
                    var mouseWorldPosition = mouseRay.GetPoint(distance);
                    var mouseWorldPositionDiff = _mouseWorldPositionStart - mouseWorldPosition;
                
                    mouseWorldPositionDiff.y = 0;
                    transform.position += mouseWorldPositionDiff;
                }
            }
        }

        private void CheckZoom()
        {
            var zoomAmount = Input.GetAxis("Mouse ScrollWheel") * zoomForce;
            if (Mathf.Abs(zoomAmount) > 0.01f) Zoom(zoomAmount);
        }

        private void Zoom(float amount)
        {
            var pos = transform.position;
        
            transform.Translate(0, 0, amount * zoomForce * Time.deltaTime, Space.Self);

            if (transform.position.y <= zoomMin) transform.position = new Vector3(pos.x, zoomMin, pos.z);
            if (transform.position.y >= zoomMax) transform.position = new Vector3(pos.x, zoomMax, pos.z);
        }

        private void SetTransform()
        {
            var cameraTransform = _camera.transform;
            _cameraPosition = cameraTransform.position;
            _cameraRotation = cameraTransform.rotation;
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
