using Core.Globals.Cursors;
using UnityEngine;

namespace Core.Test.Scripts
{
    public class TestHouseHover : MonoBehaviour
    {
        public GameObject test1;
        public GameObject test2;
    
        private void OnMouseEnter()
        {
            if (GlobalCursors.Ecursor.Equals(GlobalCursors.ECursor.Grab)) return;
            
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorClicHouse, GlobalCursors.ECursor.Clic);
        
            test1.SetActive(false);
            test2.SetActive(true);
        }

        private void OnMouseExit()
        {
            Cursor.SetCursor(GlobalCursors.Instance.CursorHand, GlobalCursors.HotSpot, CursorMode.Auto);
            GlobalCursors.Ecursor = GlobalCursors.ECursor.Hand;
        
            test2.SetActive(false);
            test1.SetActive(true);
        }
    
        private void OnMouseOver()
        {
            if (GlobalCursors.Ecursor.Equals(GlobalCursors.ECursor.Grab) || 
                GlobalCursors.Ecursor.Equals(GlobalCursors.ECursor.Clic)) return;
            
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorClicHouse, GlobalCursors.ECursor.Clic);
        }
    }
}
