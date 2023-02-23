using UnityEngine;

namespace Core.Test.Scripts
{
    public class CubeHover : MonoBehaviour
    {
        private Color originalColor; // Couleur d'origine du cube
        private Color hoverColor = Color.red; // Couleur à appliquer lors du survol de la souris

        private void Start()
        {
            originalColor = GetComponent<Renderer>().material.color;
        }

        private void OnMouseEnter()
        {
            GetComponent<Renderer>().material.color = hoverColor;
        }

        private void OnMouseExit()
        {
            GetComponent<Renderer>().material.color = originalColor;
        }
    }
}