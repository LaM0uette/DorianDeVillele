using Core.Globals;
using Core.GrabCamera.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.House
{
    public class HouseWorldHover : MonoBehaviour
    {
        #region Statements

        private Camera _camera;
        private Vector3 _cameraWorldPosition;
        
        //
        public static Vector3 savedCameraPosition;

        public void LoadScene()
        {
            savedCameraPosition = _camera.transform.position;
            SceneManager.LoadScene("Test1");
        }
        //

        private void Awake()
        {
            _camera = Camera.main;
        }

        #endregion

        //

        #region Actions

        private void OnMouseExit()
        {
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorHand);
        }

        private void OnMouseOver()
        {
            if (!GlobalCursors.Instance.Ecursor.Equals(GlobalCursors.ECursor.Hand)) return;
            
            Debug.Log("test");
            
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorClicHouse, GlobalCursors.ECursor.Clic);
        }
        
        private void OnMouseDown()
        {
            _cameraWorldPosition = _camera.transform.position;
        }

        private void OnMouseUp()
        {
            if (!_cameraWorldPosition.Equals(_camera.transform.position)) return;
            
            Debug.Log("MouseUp");
            LoadScene();
        }

        #endregion
    }
}
