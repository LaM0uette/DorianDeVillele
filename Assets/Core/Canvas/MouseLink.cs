using UnityEngine;

namespace Core.Canvas
{
    public class MouseLink : MonoBehaviour
    {
        #region Statements

        [SerializeField] private string _url;

        #endregion
        
        #region Events

        private void OnMouseDown()
        {
            Application.OpenURL(_url);
        }

        #endregion
    }
}
