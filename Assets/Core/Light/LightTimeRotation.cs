using System;
using UnityEngine;

namespace Core.Light
{
    public class LightTimeRotation : MonoBehaviour
    {
        private UnityEngine.Light directionalLight;

        private void Start()
        {
            directionalLight = GetComponent<UnityEngine.Light>();
            SetLight();
        }

        private void SetLight()
        {
            var currentTime = DateTime.Now;
            var hour = currentTime.Hour;

            Vector3 rotation;

            switch (hour)
            {
                case 4:
                case 5:
                    directionalLight.enabled = false;
                    return;
                case 6:
                case 7:
                    rotation = new Vector3(20, -60, 0);
                    break;
                case 8:
                case 9:
                    rotation = new Vector3(40, -75, 0);
                    break;
                case 10:
                case 11:
                    rotation = new Vector3(50, -40, 0);
                    break;
                case 12:
                case 13:
                    rotation = new Vector3(60, -20, 0);
                    break;
                case 14:
                case 15:
                    rotation = new Vector3(50, 0, 0);
                    break;
                case 16:
                case 17:
                    rotation = new Vector3(40, 30, 0);
                    break;
                case 18:
                case 19:
                    rotation = new Vector3(20, 60, 0);
                    break;
                case 20:
                case 21:
                    rotation = new Vector3(10, 115, 0);
                    break;
                default:
                    directionalLight.enabled = false;
                    return;
            }

            directionalLight.enabled = true;
            directionalLight.transform.rotation = Quaternion.Euler(rotation);
        }
    }
}
