using System;
using Core.Globals.Tasks;
using UnityEngine;

namespace Core.Canvas
{
    public class MouseSendMail : MonoBehaviour
    {
        #region Statements

        [SerializeField] private string _mail;
        private Uri _mailtoLink;

        private void Start()
        {
            _mailtoLink= new Uri($"mailto:{_mail}");
        }

        #endregion

        #region Functions

        private void OpenMail()
        {
            UrlTasks.OpenUrl(_mailtoLink.AbsoluteUri);
        }

        #endregion
        
        #region Events

        private void OnMouseDown()
        {
            OpenMail();
        }

        private void Update()
        {
            if (Input.GetMouseButton(2)) OpenMail();
        }

        #endregion
    }
}
