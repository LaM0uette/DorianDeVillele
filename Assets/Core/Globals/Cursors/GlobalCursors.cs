using UnityEngine;

namespace Core.Globals.Cursors
{
    public class GlobalCursors : MonoBehaviour
    {
        #region Statements

        public static GlobalCursors Instance;
        public static readonly Vector2 HotSpot = new (32, 32);
        public static ECursor Ecursor;
        
        public Texture2D CursorHand;
        public Texture2D CursorGrab;
        public Texture2D CursorClic;
        public Texture2D CursorClicHouse;

        public enum ECursor
        {
            Hand,
            Grab,
            Clic
        }

        private void Awake()
        {
            Instance ??= this;
        }
        
        private void Start()
        {
            SetHandCursor(Instance.CursorHand);
        }

        #endregion

        #region Functions

        public static void SetHandCursor(Texture2D texture2D, ECursor eCursor = ECursor.Hand)
        {
            Cursor.SetCursor(texture2D, HotSpot, CursorMode.Auto);
            Ecursor = eCursor;
        }

        #endregion
    }
}
