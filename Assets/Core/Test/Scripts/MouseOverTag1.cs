using Core.Globals;
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
            if (Constants.Instance.Ecursor.Equals(Constants.ECursor.Grab) ||
                Constants.Instance.Ecursor.Equals(Constants.ECursor.Eye)) return;
            
            Cursor.SetCursor(Constants.Instance.CursorClic, Constants.Instance.HotSpot, CursorMode.Auto);
            Constants.Instance.Ecursor = Constants.ECursor.Clic;
            
            _outline.enabled = true;
        }

        private void OnMouseExit()
        {
            Cursor.SetCursor(Constants.Instance.CursorHand, Constants.Instance.HotSpot, CursorMode.Auto);
            Constants.Instance.Ecursor = Constants.ECursor.Hand;
            
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
            if (Constants.Instance.Ecursor.Equals(Constants.ECursor.Grab) || 
                Constants.Instance.Ecursor.Equals(Constants.ECursor.Clic)) return;
            
            Cursor.SetCursor(Constants.Instance.CursorClic, Constants.Instance.HotSpot, CursorMode.Auto);
            Constants.Instance.Ecursor = Constants.ECursor.Clic;
        }
    }
}
