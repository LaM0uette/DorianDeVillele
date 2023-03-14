using UnityEngine;

namespace Core.Test.Scripts
{
    public class AdjustCameraFOV : MonoBehaviour
    {
        public float initialFOV = 58.0f;
        
        private Camera _camera;
        
        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Start()
        {
            _camera = GetComponent<Camera>();
            AdjustFOV();
        }

        private void AdjustFOV()
        {
            var aspectRatio = (float)Screen.width / Screen.height;
            var fov = 2.7f * Mathf.Atan(Mathf.Tan(initialFOV * Mathf.Deg2Rad / 2.0f) / aspectRatio) * Mathf.Rad2Deg;
            
            _camera.fieldOfView = fov < initialFOV ? initialFOV : fov;

            Debug.Log(_camera.fieldOfView);
        }
    }
}
