using UnityEngine;

namespace Core.Test.Scripts
{
    public class UiTestLookAtCamera : MonoBehaviour
    {
        private Camera cameraMain;

        private void Awake()
        {
            cameraMain = Camera.main;
        }

        private void LateUpdate()
        {
            transform.LookAt(transform.position + Camera.main!.transform.rotation * Vector3.forward, cameraMain.transform.rotation * Vector3.up);
        }
    }
}
