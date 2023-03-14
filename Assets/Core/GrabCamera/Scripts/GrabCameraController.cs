using Core.Globals.Cursors;
using UnityEngine;

namespace Core.GrabCamera.Scripts
{
    public class GrabCameraController : MonoBehaviour
    {
        #region Statements

        // Modifiers
        [SerializeField] private float rotationSpeed = 150f;
        [SerializeField] private float clampMin = 15f;
        [SerializeField] private float clampMax = 50f;
    
        [SerializeField] private float zoomForce = 30f;
        [SerializeField] private float zoomMin = 2f;
        [SerializeField] private float zoomMax = 8f;

        // World
        private Camera _camera;
        private Ray _mouseRay;
        private Vector3 _mouseWorldPositionStart;

        private void Awake()
        {
            _camera = Camera.main;
        }

        #endregion

        #region Functions

        private void Pan()
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

        private void CamOrbit()
        {
            if (!Input.GetAxis("Mouse Y").Equals(0) || !Input.GetAxis("Mouse X").Equals(0))
            {
                var verticalInput = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
                var horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

                // Limite de rotation verticale
                var currentRotation = transform.rotation.eulerAngles;
                var newVerticalRotation = Mathf.Clamp(currentRotation.x - verticalInput, clampMin, clampMax);
                transform.rotation = Quaternion.Euler(newVerticalRotation, currentRotation.y, currentRotation.z);

                transform.Rotate(Vector3.up, horizontalInput, Space.World);
            }
        }
    
        private void Zoom(float amount)
        {
            var pos = transform.position;
        
            transform.Translate(0, 0, amount * zoomForce * Time.deltaTime, Space.Self);

            if (transform.position.y <= zoomMin) transform.position = new Vector3(pos.x, zoomMin, pos.z);
            if (transform.position.y >= zoomMax) transform.position = new Vector3(pos.x, zoomMax, pos.z);
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

        #endregion

        #region Events

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _mouseRay = _camera.ScreenPointToRay(Input.mousePosition);
                _mouseWorldPositionStart = GetRayIntersectionWithYPlane(_mouseRay, 0f);
            }

            if (Input.GetMouseButton(0))
            {
                if (!GlobalCursors.Instance.Ecursor.Equals(GlobalCursors.ECursor.Grab)) 
                    GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorGrab, GlobalCursors.ECursor.Grab);
                
                Pan();
            }
            else if (Input.GetMouseButton(1))
            {
                // if (!GlobalCursors.Instance.Ecursor.Equals(GlobalCursors.ECursor.Eye)) 
                //     GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorEye, GlobalCursors.ECursor.Eye);
                //
                // CamOrbit();
            }
            else
            {
                if (!GlobalCursors.Instance.Ecursor.Equals(GlobalCursors.ECursor.Hand) &&
                    !GlobalCursors.Instance.Ecursor.Equals(GlobalCursors.ECursor.Clic))
                {
                    GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorHand);
                }
            }

            var zoomAmount = Input.GetAxis("Mouse ScrollWheel") * zoomForce;
            if (Mathf.Abs(zoomAmount) > 0.01f)
            {
                Zoom(zoomAmount);
            }
        }

        #endregion
    }
}
