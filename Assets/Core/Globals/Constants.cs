using System;
using UnityEngine;

namespace Core.Globals
{
    public class Constants : MonoBehaviour
    {
        public static Constants Instance;

        public Texture2D CursorHand;
        public Texture2D CursorGrab;
        public Texture2D CursorEye;
        public Texture2D CursorClic;
        [NonSerialized] public Vector2 HotSpot = new (32, 32);

        private void Awake()
        {
            if (Instance is null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
