using UnityEngine;

namespace Core.Scripts.Globals.Managers
{
    public class CursorManager : MonoBehaviour
    {
        #region Statements

        public enum CursorState
        {
            Hand,
            Grab,
            Clic,
            ClickHouse
        }
        
        public static CursorManager Instance;
        public static CursorState CurrentCursorState { get; private set; }

        public Texture2D CursorHand;
        public Texture2D CursorGrab;
        public Texture2D CursorClic;
        public Texture2D CursorClicHouse;
        
        private static readonly Vector2 _hotSpot = new (32, 32);
        
        private void Awake()
        {
            if (Instance is null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Instance.SetCursor(CursorState.Hand);
        }

        #endregion

        #region Functions

        public void SetCursor(CursorState state)
        {
            CurrentCursorState = state;

            switch (state)
            {
                case CursorState.Hand: Cursor.SetCursor(CursorHand, _hotSpot, CursorMode.Auto); break;
                case CursorState.Grab: Cursor.SetCursor(CursorGrab, _hotSpot, CursorMode.Auto); break;
                case CursorState.Clic: Cursor.SetCursor(CursorClic, _hotSpot, CursorMode.Auto); break;
                case CursorState.ClickHouse: Cursor.SetCursor(CursorClicHouse, _hotSpot, CursorMode.Auto); break;
                default: Cursor.SetCursor(CursorHand, _hotSpot, CursorMode.Auto); break;
            }
        }
        
        #endregion
    }
}
