using Core.Globals;
using UnityEngine;

namespace Core.Test.Scripts
{
    public class TestHouseHover : MonoBehaviour
    {
        public GameObject test1;
        public GameObject test2;
    
        private void OnMouseEnter()
        {
            if (GlobalCursors.Instance.Ecursor.Equals(GlobalCursors.ECursor.Grab) ||
                GlobalCursors.Instance.Ecursor.Equals(GlobalCursors.ECursor.Eye)) return;
            
            Cursor.SetCursor(GlobalCursors.Instance.CursorClic, GlobalCursors.Instance.HotSpot, CursorMode.Auto);
            GlobalCursors.Instance.Ecursor = GlobalCursors.ECursor.Clic;
        
            test1.SetActive(false);
            test2.SetActive(true);
        }

        private void OnMouseExit()
        {
            Cursor.SetCursor(GlobalCursors.Instance.CursorHand, GlobalCursors.Instance.HotSpot, CursorMode.Auto);
            GlobalCursors.Instance.Ecursor = GlobalCursors.ECursor.Hand;
        
            test2.SetActive(false);
            test1.SetActive(true);
        }
    
        private void OnMouseOver()
        {
            if (GlobalCursors.Instance.Ecursor.Equals(GlobalCursors.ECursor.Grab) || 
                GlobalCursors.Instance.Ecursor.Equals(GlobalCursors.ECursor.Clic)) return;
            
            Cursor.SetCursor(GlobalCursors.Instance.CursorClic, GlobalCursors.Instance.HotSpot, CursorMode.Auto);
            GlobalCursors.Instance.Ecursor = GlobalCursors.ECursor.Clic;
        }
    }
}
