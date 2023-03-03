using System;
using UnityEngine;

namespace Core.Globals
{
    public class GlobalCursors : MonoBehaviour
    {
        #region Statements

        public static GlobalCursors Instance;

        public Texture2D CursorHand;
        public Texture2D CursorGrab;
        public Texture2D CursorEye;
        public Texture2D CursorClic;
        [NonSerialized] public Vector2 HotSpot = new (32, 32);
        [NonSerialized] public ECursor Ecursor;

        public enum ECursor
        {
            Hand,
            Grab,
            Clic,
            Eye
        }

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

        #endregion

        //

        #region Functions

        public static void SetHandCursor(Texture2D texture2D, ECursor eCursor = ECursor.Hand)
        {
            Cursor.SetCursor(texture2D, Instance.HotSpot, CursorMode.Auto);
            Instance.Ecursor = eCursor;
        }

        #endregion
    }
}