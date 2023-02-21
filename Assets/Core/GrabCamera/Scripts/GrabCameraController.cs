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
    
        //Cursor
        public Texture2D cursorHand;
        public Texture2D cursorHandClosed;
        public Texture2D cursorEye;
        private Vector2 _hotSpot = new (32, 32);
        private ECursor _eCursor;

        private enum ECursor
        {
            Hand,
            HandClosed,
            Eye
        }
    
        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Start()
        {
            SetHandCursor(cursorHand);
        }

        #endregion

        //

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
    
        private Vector3 GetRayIntersectionWithYPlane(Ray ray, float y)
        {
            if (ray.direction.y == 0)
            {
                return ray.GetPoint(ray.origin.y);
            }

            float t = (y - ray.origin.y) / ray.direction.y;
            return ray.GetPoint(t);
        }
    
        private void SetHandCursor(Texture2D texture2D, ECursor eCursor = ECursor.Hand)
        {
            Cursor.SetCursor(texture2D, _hotSpot, CursorMode.Auto);
            _eCursor = eCursor;
        }

        #endregion

        //

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
                if (!_eCursor.Equals(ECursor.HandClosed)) SetHandCursor(cursorHandClosed, ECursor.HandClosed);
                Pan();
            }
            else if (Input.GetMouseButton(1))
            {
                if (!_eCursor.Equals(ECursor.Eye)) SetHandCursor(cursorEye, ECursor.Eye);
                CamOrbit();
            }
            else
            {
                if (!_eCursor.Equals(ECursor.Hand)) SetHandCursor(cursorHand);
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
