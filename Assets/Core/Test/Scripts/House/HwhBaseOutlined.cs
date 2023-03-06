using Core.Globals;
using EPOOutline;
using UnityEngine;

namespace Core.Test.Scripts.House
{
    public class HwhBaseOutlined : MonoBehaviour
    {
        #region Statements

        private Vector3 _cameraWorldPosition;
        private Outlinable _outlinable;
        
        private void Awake()
        {
            _outlinable = transform.Find("Model").GetComponent<Outlinable>();
        }

        #endregion

        #region Functions

        private void CheckOutlinableIsEnabled()
        {
            if (_outlinable.enabled || !GlobalCursors.Instance.Ecursor.Equals(GlobalCursors.ECursor.Clic)) 
                return;
            
            _outlinable.enabled = true;
        }

        #endregion

        #region Actions

        private void OnMouseExit()
        {
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorHand);
            _outlinable.enabled = false;
        }

        private void OnMouseOver()
        {
            CheckOutlinableIsEnabled();
                
            if (!GlobalCursors.Instance.Ecursor.Equals(GlobalCursors.ECursor.Hand)) return;
            
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorClicHouse, GlobalCursors.ECursor.Clic);
        }

        #endregion
    }
}
