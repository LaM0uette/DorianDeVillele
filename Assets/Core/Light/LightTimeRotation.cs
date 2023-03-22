using System;
using UnityEngine;

namespace Core.Light
{
    public class LightTimeRotation : MonoBehaviour
    {
        public float latitude = 46.6f;

        private UnityEngine.Light directionalLight;

        private void Start()
        {
            directionalLight = GetComponent<UnityEngine.Light>();
        }

        private void Update()
        {
            if (directionalLight == null || directionalLight.type != LightType.Directional) return;

            DateTime currentTime = DateTime.Now;
            float hours = currentTime.Hour + currentTime.Minute / 60f;

            // Calculer l'angle de rotation en fonction de l'heure actuelle (0-360 degrés)
            float hourAngle = Mathf.Lerp(-180, 180, hours / 24f);

            // Calculer la hauteur du soleil en fonction de la latitude et de l'heure actuelle (-90 à 90 degrés)
            float sunHeightAngle = Mathf.Lerp(-90, 90, Mathf.InverseLerp(0, 24, Mathf.Abs(hours - 12))) + latitude;

            // Appliquer la rotation de la lumière directionnelle
            Quaternion rotation = Quaternion.Euler(new Vector3(sunHeightAngle, hourAngle, 0f));
            directionalLight.transform.rotation = rotation;
        }
    }
}
