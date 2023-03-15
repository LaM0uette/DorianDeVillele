using System;
using UnityEngine;

namespace Core.Test.Scripts
{
    public class AdjustCameraFOV : MonoBehaviour
    {
        public float initialFOV = 58.0f;
        
        private Camera _camera;
        private Vector2 previousScreenSize;
        private float _epsilon = 0.0001f;
        
        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Start()
        {
            _camera = GetComponent<Camera>();
            previousScreenSize = new Vector2(Screen.width, Screen.height);
            
            AdjustFOV();
        }

        private void AdjustFOV()
        {
            var aspectRatio = (float)Screen.width / Screen.height;
            var fov = 2.7f * Mathf.Atan(Mathf.Tan(initialFOV * Mathf.Deg2Rad / 2.0f) / aspectRatio) * Mathf.Rad2Deg;
            
            _camera.fieldOfView = fov < initialFOV ? initialFOV : fov;
        }
        
        private void Update()
        {
            if (Math.Abs(Screen.width - previousScreenSize.x) < _epsilon && Math.Abs(Screen.height - previousScreenSize.y) < _epsilon) 
                return;
            
            AdjustFOV();
            previousScreenSize = new Vector2(Screen.width, Screen.height);
        }
    }
}
