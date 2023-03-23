using Core.Globals.Cursors;
using Core.GrabCamera.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Canvas
{
    public class MouseHoverExit : MonoBehaviour
    {
        #region Statements

        private TextMeshProUGUI _text;
        private Image _img;
    
        private void Start()
        {
            _text = transform.Find("Text").GetComponent<TextMeshProUGUI>();
            _img = transform.Find("Img").GetComponent<Image>();
        }

        #endregion

        #region Events

        private void OnMouseEnter()
        {
            _text.color = new Color32(72, 221, 32, 255);
            _img.color = new Color32(72, 221, 32, 255);
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorClicHouse, GlobalCursors.ECursor.Clic);
        }

        private void OnMouseExit()
        {
            _text.color = new Color32(197, 197, 197, 255);
            _img.color = new Color32(197, 197, 197, 255);
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorHand);
        }
    
        private void OnMouseUp()
        {
            SceneLoader.Instance.LoadNewScene("DorianDeVillele");
        }

        #endregion
    }
}
