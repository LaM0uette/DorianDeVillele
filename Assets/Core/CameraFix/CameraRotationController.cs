using UnityEngine;

namespace Core.CameraFix
{
    public class CameraRotationController : MonoBehaviour
    {
        #region Statements

        public AnimationCurve animationCurve;
        public float animationDuration = 1.0f;

        private float animationProgress;
        private float animationSpeed;
        private Quaternion startRotation;

        private void Start()
        {
            startRotation = transform.rotation;
        }

        #endregion

        #region Functions

        public void StartAnimation()
        {
            animationSpeed = 1.0f / animationDuration;
        }

        #endregion

        #region Events

        private void Update()
        {
            if (!(animationSpeed > 0.0f)) return;
            
            animationProgress += Time.deltaTime / animationDuration;
            
            if (animationProgress >= 1.0f)
            {
                animationProgress = 0.0f;
                animationSpeed = 0.0f;
                transform.rotation = startRotation;
            }
            else
            {
                var angle = Mathf.Lerp(0.0f, 360.0f, animationCurve.Evaluate(animationProgress));
                transform.rotation = startRotation * Quaternion.Euler(0.0f, 0.0f, angle);
            }
        }

        #endregion
    }
}
