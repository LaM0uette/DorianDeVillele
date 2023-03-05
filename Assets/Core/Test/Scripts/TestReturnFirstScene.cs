using Core.GrabCamera.Scripts;
using UnityEngine;

namespace Core.Test.Scripts
{
    public class TestReturnFirstScene : MonoBehaviour
    {
        #region Statements
        
        private Camera _camera;
        
        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Start()
        {
            _camera.transform.position = new Vector3(SceneLoader.Xposition, 0, 0);
        }

        #endregion

        #region Events

        private void OnMouseEnter()
        {
            SceneLoader.LoadNewScene("DorianDeVillele");
        }

        #endregion
    }
}
