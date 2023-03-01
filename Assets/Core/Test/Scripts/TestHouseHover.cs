using Core.Globals;
using Core.GrabCamera.Scripts;
using UnityEngine;

namespace Core.Test.Scripts
{
    public class TestHouseHover : MonoBehaviour
    {
        public Texture2D cursorHand;
        public Texture2D cursorClic;
        public Vector2 hotSpot = new (32, 32);
    
        public GameObject test1;
        public GameObject test2;
    
        private void OnMouseEnter()
        {
            if (Constants.Instance.Ecursor.Equals(Constants.ECursor.Grab) ||
                Constants.Instance.Ecursor.Equals(Constants.ECursor.Eye)) return;
            
            Cursor.SetCursor(cursorClic, hotSpot, CursorMode.Auto);
            Constants.Instance.Ecursor = Constants.ECursor.Clic;
        
            test1.SetActive(false);
            test2.SetActive(true);
        }

        private void OnMouseExit()
        {
            Cursor.SetCursor(cursorHand, hotSpot, CursorMode.Auto);
            Constants.Instance.Ecursor = Constants.ECursor.Hand;
        
            test2.SetActive(false);
            test1.SetActive(true);
        }
    
        private void OnMouseOver()
        {
            if (Constants.Instance.Ecursor.Equals(Constants.ECursor.Grab) || 
                Constants.Instance.Ecursor.Equals(Constants.ECursor.Clic)) return;
            
            Cursor.SetCursor(cursorClic, hotSpot, CursorMode.Auto);
            Constants.Instance.Ecursor = Constants.ECursor.Clic;
        }
    }
}
