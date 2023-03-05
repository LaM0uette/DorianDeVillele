using System;
using Core.Globals;
using EPOOutline;
using TMPro;
using UnityEngine;

namespace Core.Test.Scripts.House
{
    public class HwhBase2Outlined : MonoBehaviour
    {
        #region Statements

        public GameObject CadreGris;
        public GameObject CadreVert;
        public TextMeshProUGUI textMp;
        
        private Camera _camera;
        private Vector3 _cameraWorldPosition;
        private Outlinable _outlinable;

        private void Awake()
        {
            _camera = Camera.main;
            _outlinable = transform.Find("Model").GetComponent<Outlinable>();
        }

        #endregion

        #region Functions

        private void CheckCadreIsEnabled()
        {
            if (CadreVert.activeInHierarchy || !GlobalCursors.Instance.Ecursor.Equals(GlobalCursors.ECursor.Clic)) 
                return;
            
            CadreGris.SetActive(false);
            CadreVert.SetActive(true);

            try
            {
                textMp.color = new Color32(72, 221, 32, 255);
            }
            catch (Exception)
            {
                //
            }
            
            _outlinable.enabled = true;
        }

        #endregion

        #region Actions

        private void OnMouseExit()
        {
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorHand);
            
            CadreGris.SetActive(true);
            CadreVert.SetActive(false);

            try
            {
                textMp.color = new Color32(197, 197, 197, 255);
            }
            catch (Exception)
            {
                //
            }
            
            _outlinable.enabled = false;
        }

        private void OnMouseOver()
        {
            CheckCadreIsEnabled();
            
            if (!GlobalCursors.Instance.Ecursor.Equals(GlobalCursors.ECursor.Hand)) return;
            
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorClicHouse, GlobalCursors.ECursor.Clic);
        }
        
        private void OnMouseDown()
        {
            _cameraWorldPosition = _camera.transform.position;
        }

        private void OnMouseUp()
        {
            if (!_cameraWorldPosition.Equals(_camera.transform.position)) return;
            
            Debug.Log("MouseUp");
        }

        #endregion
    }
}
