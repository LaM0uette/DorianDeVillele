using UnityEngine;

namespace Core.GrabCamera.Scripts
{
    public class SaveCameraPosition : MonoBehaviour
    {
        private Vector3 cameraPosition;

        private void OnApplicationQuit()
        {
            cameraPosition = transform.position;
        }
    }
}
