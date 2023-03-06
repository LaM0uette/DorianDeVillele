using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.GrabCamera.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        #region Statements
        
        public static string CamPositionName { get; private set; }

        private static Vector3 _cameraPosition = Vector3.zero;
        private static Quaternion _cameraRotation;
        
        private void Start()
        {
            if (CheckCameraPositionEqualZero()) return;

            SetCameraTransform();
        }

        #endregion

        #region Functions
        
        private static bool CheckCameraPositionEqualZero() => _cameraPosition.Equals(Vector3.zero);
        
        private void SetCameraTransform()
        {
            var cameraTransform = transform;
            
            cameraTransform.position = _cameraPosition;
            cameraTransform.rotation = _cameraRotation;
        }

        private static void SetCamPositionName(string camPositionName) => CamPositionName = camPositionName;
        
        public static void LoadNewScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public static void LoadNewScene(Transform transform, string scene, string camPositionName = "")
        {
            SetCamPositionName(camPositionName);
                
            _cameraPosition = transform.position;
            _cameraRotation = transform.rotation;
            
            SceneManager.LoadScene(scene);
        }
        
        #endregion

        #region Events

        private void OnApplicationQuit() => _cameraPosition = transform.position;

        #endregion
    }
}
