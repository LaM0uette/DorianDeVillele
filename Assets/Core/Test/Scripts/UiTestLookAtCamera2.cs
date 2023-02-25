using UnityEngine;

namespace Core.Test.Scripts
{
    public class UiTestLookAtCamera2 : MonoBehaviour
    {
        private Camera cameraMain;

        private void Awake()
        {
            cameraMain = Camera.main;
        }

        private void LateUpdate()
        {
            var rotation = cameraMain.transform.rotation;
            transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
        }
    }
}
