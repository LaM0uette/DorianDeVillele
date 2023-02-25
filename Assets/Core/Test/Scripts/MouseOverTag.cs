using System;
using Core.GrabCamera.Scripts;
using EPOOutline;
using UnityEngine;

namespace Core.Test.Scripts
{
    public class MouseOverTag : MonoBehaviour
    {
        public Texture2D cursorHand;
        public Texture2D cursorClic;
        public Vector2 hotSpot = new (32, 32);
        
        private Outlinable _outlinable;
        private Camera _camera;
        private Vector3 _cameraWorldPosition;
        
        private void Awake()
        {
            _camera = Camera.main;
            //_outlinable = GetComponent<Outlinable>();
        }

        private void OnMouseEnter()
        {
            if (GrabCameraController._eCursor.Equals(GrabCameraController.ECursor.Grab) ||
                GrabCameraController._eCursor.Equals(GrabCameraController.ECursor.Eye)) return;
            
            Cursor.SetCursor(cursorClic, hotSpot, CursorMode.Auto);
            GrabCameraController._eCursor = GrabCameraController.ECursor.Clic;
            
            //_outlinable.OutlineParameters.Enabled = true;
        }

        private void OnMouseExit()
        {
            Cursor.SetCursor(cursorHand, hotSpot, CursorMode.Auto);
            GrabCameraController._eCursor = GrabCameraController.ECursor.Hand;
            
            //_outlinable.OutlineParameters.Enabled = false;
        }

        private void OnMouseDown()
        {
            _cameraWorldPosition = _camera.transform.position;
        }

        private void OnMouseUp()
        {
            if (_cameraWorldPosition.Equals(_camera.transform.position)) Debug.Log("MouseUp");
        }
    }
}
