using Core.Globals.Canvas;
using Core.Globals.Cursors;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Canvas.Icons
{
    public class IconsHover : MonoBehaviour
    {
        #region Statements

        private Image img;

        private void Awake()
        {
            img = GetComponent<Image>();
        }

        #endregion

        #region Events

        private void OnMouseEnter()
        {
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorClic, GlobalCursors.ECursor.Clic);
            
            img.color = new Color32(72, 221, 32, 255);
        }

        private void OnMouseExit()
        {
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorHand);
            
            img.color = new Color32(197, 197, 197, 255);
        }

        #endregion
    }
}
