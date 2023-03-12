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

        private Image _img;
        private Vector3 _localScale;
        private const float _scale = 0.0022f;

        private void Awake()
        {
            _img = GetComponent<Image>();
            _localScale = transform.localScale;
        }

        #endregion

        #region Events

        private void OnMouseEnter()
        {
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorClic, GlobalCursors.ECursor.Clic);
            
            _img.color = new Color32(72, 221, 32, 255);
            transform.localScale = new Vector3(_scale, _scale, _scale);
        }

        private void OnMouseExit()
        {
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorHand);
            
            _img.color = new Color32(197, 197, 197, 255);
            transform.localScale = _localScale;
        }

        #endregion
    }
}
