using Core.Globals.Tasks;
using UnityEngine;

namespace Core.Canvas
{
    public class MouseLink : MonoBehaviour
    {
        #region Statements

        [SerializeField] private string _url;

        #endregion
        
        #region Functions

        private void OpenLink()
        {
            UrlTasks.OpenUrl(_url);
        }

        #endregion
        
        #region Events

        private void OnMouseDown()
        {
            OpenLink();
        }
        
        private void Update()
        {
            if (Input.GetMouseButton(2)) OpenLink();
        }

        #endregion
    }
}
