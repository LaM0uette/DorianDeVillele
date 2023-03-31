using Core.Globals;
using Core.House.CameraPosition;
using UnityEngine;

namespace Core.House
{
    public class HouseClicAction : MonoBehaviour
    {
        #region Statements
        
        [SerializeField] private string SceneName = "House";
        [SerializeField] private CameraPositionName CameraPositionName;

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
            SceneLoader.Instance.LoadNewScene(SceneName, CameraPositionName);
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
