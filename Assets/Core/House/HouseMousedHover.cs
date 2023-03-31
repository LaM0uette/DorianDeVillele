using Core.Globals.Cursors;
using UnityEngine;

namespace Core.House
{
    public class HouseMousedHover : MonoBehaviour
    {
        #region Actions

        private void OnMouseExit()
        {
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorHand);
        }

        private void OnMouseOver()
        {
            if (!GlobalCursors.Ecursor.Equals(GlobalCursors.ECursor.Hand)) return;
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorClicHouse, GlobalCursors.ECursor.Clic);
        }

        #endregion
    }
}
