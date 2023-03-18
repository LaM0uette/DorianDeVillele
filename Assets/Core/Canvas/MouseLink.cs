using System.Diagnostics;
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
            Process.Start(_url);
        }

        #endregion
    }
}
