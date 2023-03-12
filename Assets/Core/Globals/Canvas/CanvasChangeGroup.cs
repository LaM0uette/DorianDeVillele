using System.Collections.Generic;

namespace Core.Globals.Canvas
{
    public static class CanvasChangeGroup
    {
        #region Statements

        public static int CurrentTitle;
        
        public enum ArrowSide
        {
            Left,
            Right
        }

        private static readonly Dictionary<int, string> _DICT_GROUP = new()
        {
            {0, "Programmation"},
            {1, "Logiciels"},
            {2, "Divers"}
        };

        #endregion

        #region Functions

        private static void CheckLimitCurrentTitle()
        {
            if (CurrentTitle < 0)
                CurrentTitle = _DICT_GROUP.Count - 1;
            else if (CurrentTitle > _DICT_GROUP.Count - 1)
                CurrentTitle = 0;
        }

        public static string GetTitle()
        {
            CheckLimitCurrentTitle();
            return _DICT_GROUP[CurrentTitle];
        }

        #endregion
    }
}
