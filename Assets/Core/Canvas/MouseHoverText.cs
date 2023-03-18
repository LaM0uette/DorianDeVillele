using System.Diagnostics;
using Core.Globals.Cursors;
using TMPro;
using UnityEngine;

namespace Core.Canvas
{

    public class MouseHoverText : MonoBehaviour
    {
        #region Statements
        
        private TextMeshProUGUI _text;
    
        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        #endregion
        
        #region Events

        private void OnMouseEnter()
        {
            _text.color = new Color32(72, 221, 32, 255);
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorClicHouse, GlobalCursors.ECursor.Clic);
        }

        private void OnMouseExit()
        {
            _text.color = new Color32(197, 197, 197, 255);
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorHand);
        }
    
        private void OnMouseDown()
        {
            Process.Start("https://www.example.com");
        }

        #endregion
    
    }
}
