using Core.GrabCamera.Scripts;
using UnityEngine;

namespace Core.House
{
    public class HouseReturnMainScene : MonoBehaviour
    {
        #region Statements
        
        private Camera _camera;
        
        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Start()
        {
            _camera.transform.position = new Vector3(SceneLoader.Xposition, 2.5f, 1);
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