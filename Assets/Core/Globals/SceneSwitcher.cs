using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.GrabCamera.Scripts
{
    public class SceneSwitcher : MonoBehaviour
    {
        private Camera _mainCamera;
        public Vector3 SavedCameraPosition;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        public void LoadScene()
        {
            SavedCameraPosition = _mainCamera.transform.position;
            SceneManager.LoadScene("Test1");
        }
    }
}
