using Core.GrabCamera.Scripts;
using UnityEngine;

namespace Core.Test.Scripts
{
    public class MouseOverTag : MonoBehaviour
    {
        public Texture2D cursorHand;
        public Texture2D cursorClic;
        public Vector2 hotSpot = new (32, 32);
        
        private Camera _camera;
        private Vector3 _cameraWorldPosition;
        
        private void Awake()
        {
            _camera = Camera.main;
        }

        private void OnMouseEnter()
        {
            if (GrabCameraController._eCursor.Equals(GrabCameraController.ECursor.Grab) ||
                GrabCameraController._eCursor.Equals(GrabCameraController.ECursor.Eye)) return;
            
            Cursor.SetCursor(cursorClic, hotSpot, CursorMode.Auto);
            GrabCameraController._eCursor = GrabCameraController.ECursor.Clic;
        }

        private void OnMouseExit()
        {
            Cursor.SetCursor(cursorHand, hotSpot, CursorMode.Auto);
            GrabCameraController._eCursor = GrabCameraController.ECursor.Hand;
        }

        private void OnMouseDown()
        {
            _cameraWorldPosition = _camera.transform.position;
        }

        private void OnMouseUp()
        {
            if (!_cameraWorldPosition.Equals(_camera.transform.position)) return;
            
            Debug.Log("MouseUp");
        }

        private void OnMouseOver()
        {
            if (GrabCameraController._eCursor.Equals(GrabCameraController.ECursor.Grab) || 
                GrabCameraController._eCursor.Equals(GrabCameraController.ECursor.Clic)) return;
            
            Cursor.SetCursor(cursorClic, hotSpot, CursorMode.Auto);
            GrabCameraController._eCursor = GrabCameraController.ECursor.Clic;
        }
    }
}
