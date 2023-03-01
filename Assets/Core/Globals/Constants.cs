using UnityEngine;

namespace Core.Globals
{
    public class Constants : MonoBehaviour
    {
        public static Constants instance;

        public Texture2D CursorHand;
        public Texture2D CursorGrab;
        public Texture2D CursorEye;
        public Texture2D CursorClic;
        public static Vector2 HotSpot = new (32, 32);

        private void Awake()
        {
            if (instance is null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
