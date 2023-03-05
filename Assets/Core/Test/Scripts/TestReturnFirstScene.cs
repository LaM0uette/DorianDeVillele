using Core.House;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Test.Scripts
{
    public class TestReturnFirstScene : MonoBehaviour
    {
        private Camera _camera;
        
        private void Awake()
        {
            _camera = Camera.main;
        }
        
        private void LoadScene()
        {
            SceneManager.LoadScene("DorianDeVillele");
            _camera.transform.position = HouseWorldHover.savedCameraPosition;
        }

        private void OnMouseEnter()
        {
            LoadScene();
        }
    }
}
