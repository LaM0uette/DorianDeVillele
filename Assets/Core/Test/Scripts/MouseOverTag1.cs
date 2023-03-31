using Core.Globals.Cursors;
using EPOOutline;
using UnityEngine;

namespace Core.Test.Scripts
{
    public class MouseOverTag1 : MonoBehaviour
    {
        private Camera _camera;
        private Vector3 _cameraWorldPosition;
        
        private Outlinable _outline;

        private void Awake()
        {
            _camera = Camera.main;
            _outline = GetComponent<Outlinable>();
        }

        private void OnMouseEnter()
        {
            if (GlobalCursors.Ecursor.Equals(GlobalCursors.ECursor.Grab)) return;
            
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorClicHouse, GlobalCursors.ECursor.Clic);
            
            _outline.enabled = true;
        }

        private void OnMouseExit()
        {
            Cursor.SetCursor(GlobalCursors.Instance.CursorHand, GlobalCursors.HotSpot, CursorMode.Auto);
            GlobalCursors.Ecursor = GlobalCursors.ECursor.Hand;
            
            _outline.enabled = false;
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
            if (GlobalCursors.Ecursor.Equals(GlobalCursors.ECursor.Grab) || 
                GlobalCursors.Ecursor.Equals(GlobalCursors.ECursor.Clic)) return;
            
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorClicHouse, GlobalCursors.ECursor.Clic);
        }
    }
}
