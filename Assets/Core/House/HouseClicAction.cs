using Core.GrabCamera.Scripts;
using UnityEditor;
using UnityEngine;

namespace Core.House
{
    public class HouseClicAction : MonoBehaviour
    {
        #region Statements
        
        [SerializeField] private SceneAsset _scene;
        [SerializeField] private int _xPosition;

        private Camera _camera;
        private Vector3 _cameraWorldPosition;
        
        private void Awake()
        {
            _camera = Camera.main;
        }

        #endregion

        #region Functions

        private void LoadScene()
        {
            SceneLoader.LoadNewScene(_camera.transform, _scene.name, _xPosition);
        }

        #endregion

        #region Events

        private void OnMouseDown()
        {
            _cameraWorldPosition = _camera.transform.position;
        }

        private void OnMouseUp()
        {
            if (!_cameraWorldPosition.Equals(_camera.transform.position)) return;
            
            LoadScene();
        }

        #endregion
    }
}
