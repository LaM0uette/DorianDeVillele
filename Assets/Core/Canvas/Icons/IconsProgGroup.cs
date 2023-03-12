using Core.Globals.Canvas;
using Core.Test.Scripts;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace Core.Canvas.Icons
{
    public class IconsProgGroup : MonoBehaviour
    {
        #region Statements

        [SerializeField] private CanvasChangeGroup.ArrowSide arrow;
        [SerializeField] private TextMeshProUGUI textMp;
        
        public CameraController cameraController;
        
        [SerializeField] private GameObject Programmation;
        [SerializeField] private GameObject Logiciels;
        [SerializeField] private GameObject Divers;

        #endregion

        #region Functions

        private void SetCurrentTitle()
        {
            IncreaseCurrentTitle();
            textMp.text = CanvasChangeGroup.GetTitle();
        }
        
        private void IncreaseCurrentTitle()
        {
            if (arrow.Equals(CanvasChangeGroup.ArrowSide.Left))
                CanvasChangeGroup.CurrentTitle--;
            else
                CanvasChangeGroup.CurrentTitle++;
        }

        private void ChangeGameObject()
        {
            Programmation.SetActive(false);
            Logiciels.SetActive(false); 
            Divers.SetActive(false);
            
            switch (CanvasChangeGroup.CurrentTitle)
            {
                case 0: Programmation.SetActive(true); break;
                case 1: Logiciels.SetActive(true); break;
                case 2: Divers.SetActive(true); break;
            }
        }

        #endregion
        
        #region Events

        private void OnMouseDown()
        {
            cameraController.StartAnimation();
            
            SetCurrentTitle();
            ChangeGameObject();
        }

        #endregion
    }
}
