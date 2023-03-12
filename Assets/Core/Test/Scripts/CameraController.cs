using UnityEngine;

namespace Core.Test.Scripts
{
    public class CameraController : MonoBehaviour
    {
        public AnimationCurve animationCurve; // La courbe d'interpolation pour la vitesse
        public float animationDuration = 5.0f; // La durée de l'animation en secondes

        private float animationProgress = 0.0f; // La progression actuelle de l'animation
        private float animationSpeed = 0.0f; // La vitesse de l'animation

        private Quaternion startRotation; // L'orientation de la caméra au début de l'animation

        void Start()
        {
            startRotation = transform.rotation; // Stocker l'orientation de départ
        }

        void Update()
        {
            // Si l'animation est en cours, mettre à jour la progression
            if (animationSpeed > 0.0f)
            {
                // Calculer la progression en fonction du temps écoulé depuis le début de l'animation
                animationProgress += Time.deltaTime / animationDuration;
                if (animationProgress >= 1.0f)
                {
                    // Si l'animation est terminée, réinitialiser la progression et la vitesse
                    animationProgress = 0.0f;
                    animationSpeed = 0.0f;
                    transform.rotation = startRotation; // Remettre la caméra à sa position de départ
                }
                else
                {
                    // Sinon, calculer l'angle de rotation en fonction de la progression et de la courbe d'interpolation
                    float angle = Mathf.Lerp(0.0f, 360.0f, animationCurve.Evaluate(animationProgress));
                    transform.rotation = startRotation * Quaternion.Euler(0.0f, 0.0f, angle); // Appliquer la rotation à l'objet "CaméraController"
                }
            }
        }
        
        public void StartAnimation()
        {
            // Au clic de la souris, démarrer l'animation en définissant la vitesse
            animationSpeed = 1.0f / animationDuration;
        }
    }
}
