using UnityEngine;

namespace Core.Test.Scripts
{
    public class UiTestLookAtCamera : MonoBehaviour
    {
        private Camera mainCamera;

        void Start()
        {
            mainCamera = Camera.main;
        }

        void LateUpdate()
        {
            // Récupérer la position de la caméra et du canvas
            Vector3 cameraPosition = mainCamera.transform.position;
            Vector3 canvasPosition = transform.position;

            // Créer un vecteur direction entre la caméra et le canvas
            Vector3 direction = cameraPosition - canvasPosition;

            // Calculer la nouvelle rotation du canvas en utilisant la direction entre la caméra et le canvas
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            targetRotation.eulerAngles = new Vector3(0f, targetRotation.eulerAngles.y, 0f);

            // Appliquer la rotation au canvas
            transform.rotation = targetRotation;
            
            // Corriger l'orientation à 180 degrés
            Quaternion currentRotation = transform.rotation;
            transform.rotation = currentRotation * Quaternion.Euler(0f, 180f, 0f);
        }
    }
}
