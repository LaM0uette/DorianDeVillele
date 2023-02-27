using TMPro;
using UnityEngine;

namespace Core.Test.Scripts
{
    public class TestHouseHoverCanvas1 : MonoBehaviour
    {
        public TextMeshProUGUI textMp;
    
        private void OnMouseEnter()
        {
            textMp.color = new Color(72, 221, 32, 1f);
        }

        private void OnMouseExit()
        {
            textMp.color = new Color(197, 197, 197, 1f);
        }
    }
}
