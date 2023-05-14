using Core.Scripts.GrabCamera.InputHandler;
using UnityEngine;

namespace Core.Scripts.GrabCamera.Controller
{
    public class CameraZoomer : MonoBehaviour
    {
        #region Statements

        // Components
        private IInputHandler _inputHandler;
        private ICameraController _cameraController;

        [Header("Zoom Settings")]
        [SerializeField] private float _zoomSpeed = 10f;
        [SerializeField] private float _zoomMin = 10f;
        [SerializeField] private float _zoomMax = 600f;

        private void Awake()
        {
            _inputHandler = GetComponent<IInputHandler>();
            _cameraController = GetComponent<ICameraController>();
        }

        #endregion
        
        #region Subscriptions

        private void SubscribeInputHandler()
        {
            _inputHandler.OnZoom += HandleZoom;
        }
        
        private void UnsubscribeInputHandler()
        {
            _inputHandler.OnZoom -= HandleZoom;
        }

        #endregion

        #region Functions

        private void HandleZoom(float zoomAmount)
        {
            transform.Translate(0, 0, -zoomAmount * _zoomSpeed * Mathf.Min(Time.deltaTime, 0.2f), Space.Self);
            CheckAndSetZoomLimits();
        }

        private void CheckAndSetZoomLimits()
        {
            var posY = transform.position.y;
                
            if (posY <= _zoomMin) SetPositionY(_zoomMin); 
            else if (posY >= _zoomMax) SetPositionY(_zoomMax); 
            
            _cameraController.CheckCameraPositionLimits();
        }
        
        private void SetPositionY(float posY) => transform.Translate(0, 0, transform.position.y - posY, Space.Self);

        #endregion

        #region Events

        private void OnEnable()
        {
            SubscribeInputHandler();
        }

        private void OnDisable()
        {
            UnsubscribeInputHandler();
        }

        #endregion
    }
}
