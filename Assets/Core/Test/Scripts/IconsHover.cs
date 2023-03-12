using Core.Globals.Canvas;
using Core.Globals.Cursors;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Test.Scripts
{
    public class IconsHover : MonoBehaviour
    {
        #region Statements

        [SerializeField] private CanvasChangeGroup.ArrowSide arrow;
        [SerializeField] private TextMeshProUGUI textMp;

        private Image img;

        private void Awake()
        {
            img = GetComponent<Image>();
        }

        #endregion

        #region Functions

        private void SetCurrentTitle()
        {
            IncreaseCurrentTitle();
            textMp.text = CanvasChangeGroup.GetTitle();
        }
        
        private void IncreaseCurrentTitle()
        {
            if (arrow.Equals(CanvasChangeGroup.ArrowSide.Left))
                CanvasChangeGroup.CurrentTitle--;
            else
                CanvasChangeGroup.CurrentTitle++;
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
        
        private void OnMouseDown()
        {
            SetCurrentTitle();
        }

        #endregion
    }
}
