using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.GrabCamera.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        #region Statements
        
        public static int Xposition { get; private set; }

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
        
        private static void SetXposition(int xPosition) => Xposition = xPosition;
        
        public static void LoadNewScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }

        public static void LoadNewScene(Transform transform, string scene, int xPosition = 0)
        {
            SetXposition(xPosition);
                
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
