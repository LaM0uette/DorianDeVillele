using Core.Globals.Tasks;
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
            UrlTasks.OpenUrl(_url);
        }
        
        private void Update()
        {
            if (Input.GetMouseButton(2)) UrlTasks.OpenUrl(_url);
        }

        #endregion
    }
}
