using System;
using Core.GrabCamera.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Core.Test.Scripts
{
    public class CubeHover : MonoBehaviour
    {
        public Texture2D cursorHand;
        public Texture2D cursorClic;
        public Vector2 _hotSpot = new (32, 32);
        
        private Color[] colors = { Color.red, Color.blue, Color.green, Color.yellow, Color.magenta }; // couleurs possibles
        private Color currentColor;

        private void OnMouseEnter()
        {
            Cursor.SetCursor(cursorClic, _hotSpot, CursorMode.Auto);
            GrabCameraController._eCursor = GrabCameraController.ECursor.Clic;
        }

        private void OnMouseExit()
        {
            Cursor.SetCursor(cursorHand, _hotSpot, CursorMode.Auto);
            GrabCameraController._eCursor = GrabCameraController.ECursor.Hand;
        }

        private void OnMouseDown()
        {
            SetRandomColor();
        }

        private void SetRandomColor()
        {
            currentColor = colors[Random.Range(0, colors.Length)];

            while (currentColor.Equals(GetComponent<Renderer>().material.color))
            {
                currentColor = colors[Random.Range(0, colors.Length)];
            }
            
            GetComponent<Renderer>().material.color = currentColor;
        }
    }
}