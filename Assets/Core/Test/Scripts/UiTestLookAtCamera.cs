using UnityEngine;

namespace Core.Test.Scripts
{
    public class UiTestLookAtCamera : MonoBehaviour
    {
        private Camera mainCamera;

        private void Awake()
        {
            mainCamera = Camera.main;
        }

        private void LateUpdate()
        {
            var cameraPosition = mainCamera.transform.position;
            var canvasPosition = transform.position;
            var direction = cameraPosition - canvasPosition;

            var targetRotation = Quaternion.LookRotation(direction);
            
            targetRotation.eulerAngles = new Vector3(0f, targetRotation.eulerAngles.y, 0f);
            var transform1 = transform;
            transform1.rotation = targetRotation;
            
            // Corriger l'orientation à 180 degrés
            var currentRotation = transform1.rotation;
            transform.rotation = currentRotation * Quaternion.Euler(0f, 180f, 0f);
        }
    }
}
