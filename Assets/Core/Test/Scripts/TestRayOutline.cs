using Core.GrabCamera.Scripts;
using EPOOutline;
using UnityEngine;

namespace Core.Test.Scripts
{
    public class TestRayOutline : MonoBehaviour
    {
        public Texture2D cursorHand;
        public Texture2D cursorClic;
        public Vector2 hotSpot = new (32, 32);
        
        private Outlinable _outlinable;
        
        public LayerMask layersToDetect;
        private Camera mainCamera;

        private void Start()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, layersToDetect))
            {
                _outlinable = hitInfo.collider.GetComponent<Outlinable>();
                
                Cursor.SetCursor(cursorClic, hotSpot, CursorMode.Auto);
                GrabCameraController._eCursor = GrabCameraController.ECursor.Clic;
            
                _outlinable.OutlineParameters.Enabled = true;
            }
            else
            {
                Cursor.SetCursor(cursorHand, hotSpot, CursorMode.Auto);
                GrabCameraController._eCursor = GrabCameraController.ECursor.Hand;
            
                _outlinable.OutlineParameters.Enabled = false;
            }
        }
    }
}