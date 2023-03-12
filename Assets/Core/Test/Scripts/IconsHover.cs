using Core.Globals;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Test.Scripts
{
    public class IconsHover : MonoBehaviour
    {
        private Image img;

        private void Awake()
        {
            img = GetComponent<Image>();
        }

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
    }
}
