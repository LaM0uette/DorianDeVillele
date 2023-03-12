using Core.CameraFix;
using Core.Globals.Canvas;
using TMPro;
using UnityEngine;

namespace Core.Canvas.Icons
{
    public class IconsProgGroup : MonoBehaviour
    {
        #region Statements

        [SerializeField] private CanvasChangeGroup.ArrowSide arrow;
        [SerializeField] private TextMeshProUGUI textMp;

        [SerializeField] private GameObject Programmation;
        [SerializeField] private GameObject Logiciels;
        [SerializeField] private GameObject Divers;

        private Camera _camera;
        private CameraRotationController cameraRotationController;
        
        private void Start()
        {
            _camera = Camera.main;
            if (_camera is not null) cameraRotationController = _camera.GetComponent<CameraRotationController>();
        }

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
            cameraRotationController.StartAnimation();
            
            SetCurrentTitle();
            ChangeGameObject();
        }

        #endregion
    }
}
