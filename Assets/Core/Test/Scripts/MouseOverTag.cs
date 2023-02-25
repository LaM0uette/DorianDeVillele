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
        
        private void Start()
        {
            _outlinable = GetComponent<Outlinable>();
        }
        
        private void OnMouseEnter()
        {
            if (GrabCameraController._eCursor.Equals(GrabCameraController.ECursor.Grab) ||
                GrabCameraController._eCursor.Equals(GrabCameraController.ECursor.Eye)) return;
            
            Cursor.SetCursor(cursorClic, hotSpot, CursorMode.Auto);
            GrabCameraController._eCursor = GrabCameraController.ECursor.Clic;
            
            _outlinable.OutlineParameters.Enabled = true;
        }

        private void OnMouseExit()
        {
            Cursor.SetCursor(cursorHand, hotSpot, CursorMode.Auto);
            GrabCameraController._eCursor = GrabCameraController.ECursor.Hand;
            
            _outlinable.OutlineParameters.Enabled = false;
        }
    }
}
