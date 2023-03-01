using System;
using Core.Globals;
using UnityEngine;

namespace Core.House
{
    public class HouseWorldHover : MonoBehaviour
    {
        private void OnMouseExit()
        {
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorHand);
        }

        private void OnMouseOver()
        {
            if (!GlobalCursors.Instance.Ecursor.Equals(GlobalCursors.ECursor.Hand)) return;
            
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorClic);
        }
    }
}
