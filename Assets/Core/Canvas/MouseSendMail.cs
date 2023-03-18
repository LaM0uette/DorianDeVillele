using System;
using UnityEngine;

namespace Core.Canvas
{
    public class MouseSendMail : MonoBehaviour
    {
        #region Statements

        [SerializeField] private string _mail;

        #endregion
        
        #region Events

        private void OnMouseDown()
        {
            var mailtoLink = new Uri($"mailto:{_mail}");

            System.Diagnostics.Process.Start(mailtoLink.AbsoluteUri);
        }

        #endregion
    }
}
