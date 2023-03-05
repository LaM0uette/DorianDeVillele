using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.GrabCamera.Scripts
{
    public class SaveCameraPosition : MonoBehaviour
    {
        private static Vector3 _cameraPosition = Vector3.zero;
        private static Quaternion _cameraRotation;

        public static void LoadNewScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
        
        public static void LoadNewScene(Transform transform, string scene)
        {
            _cameraPosition = transform.position;
            _cameraRotation = transform.rotation;
            SceneManager.LoadScene(scene);
        }
        
        private void SetCameraTransform()
        {
            var cameraTransform = transform;
            cameraTransform.position = _cameraPosition;
            cameraTransform.rotation = _cameraRotation;
        }

        private void Start()
        {
            if (_cameraPosition.Equals(Vector3.zero)) return;
            
            SetCameraTransform();
        }
        
        private void OnApplicationQuit()
        {
            _cameraPosition = transform.position;
        }
    }
}
