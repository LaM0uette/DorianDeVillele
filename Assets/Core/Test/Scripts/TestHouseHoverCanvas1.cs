using Core.GrabCamera.Scripts;
using TMPro;
using UnityEngine;

namespace Core.Test.Scripts
{
    public class TestHouseHoverCanvas1 : MonoBehaviour
    {
        public TextMeshProUGUI textMp;
    
        private void OnMouseEnter()
        {
            if (GrabCameraController._eCursor.Equals(GrabCameraController.ECursor.Grab) ||
                GrabCameraController._eCursor.Equals(GrabCameraController.ECursor.Eye)) return;
            
            textMp.color = new Color32(72, 221, 32, 255);
        }

        private void OnMouseExit()
        {
            textMp.color = new Color32(197, 197, 197, 255);
        }
    }
}
