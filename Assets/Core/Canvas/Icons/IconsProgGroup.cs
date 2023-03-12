using Core.Globals.Canvas;
using Core.Globals.Cursors;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Canvas.Icons
{
    public class IconsProgGroup : MonoBehaviour
    {
        #region Statements

        [SerializeField] private CanvasChangeGroup.ArrowSide arrow;
        [SerializeField] private TextMeshProUGUI textMp;

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

        private void OnMouseDown()
        {
            SetCurrentTitle();
        }

        #endregion
    }
}
