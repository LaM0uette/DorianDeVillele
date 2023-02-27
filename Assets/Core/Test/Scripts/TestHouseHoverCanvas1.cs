using TMPro;
using UnityEngine;

namespace Core.Test.Scripts
{
    public class TestHouseHoverCanvas1 : MonoBehaviour
    {
        public TextMeshPro textMp;
    
        private void OnMouseEnter()
        {
            textMp.color = Color.green;
        }

        private void OnMouseExit()
        {
            textMp.color = Color.white;
        }
    }
}
