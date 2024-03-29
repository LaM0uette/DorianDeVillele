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

        [SerializeField] private GameObject Logos;
        
        private GameObject Programmation;
        private GameObject Sgbd;
        private GameObject Adobe;
        private GameObject Logiciels;
        private GameObject Divers;

        private Camera _camera;
        private CameraShakeRotationController cameraShakeRotationController;
        
        private void Start()
        {
            _camera = Camera.main;

            Programmation = Logos.transform.Find("Programmation").gameObject;
            Sgbd = Logos.transform.Find("Sgbd").gameObject;
            Adobe = Logos.transform.Find("Adobe").gameObject;
            Logiciels = Logos.transform.Find("Logiciels").gameObject;
            Divers = Logos.transform.Find("Divers").gameObject;
            
            if (_camera is not null) cameraShakeRotationController = _camera.GetComponent<CameraShakeRotationController>();
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
            Sgbd.SetActive(false);
            Adobe.SetActive(false);
            Logiciels.SetActive(false); 
            Divers.SetActive(false);
            
            switch (CanvasChangeGroup.CurrentTitle)
            {
                case 0: Programmation.SetActive(true); break;
                case 1: Sgbd.SetActive(true); break;
                case 2: Adobe.SetActive(true); break;
                case 3: Logiciels.SetActive(true); break;
                case 4: Divers.SetActive(true); break;
            }
        }

        #endregion
        
        #region Events

        private void OnMouseDown()
        {
            cameraShakeRotationController.StartAnimation();
            
            SetCurrentTitle();
            ChangeGameObject();
        }

        #endregion
    }
}
