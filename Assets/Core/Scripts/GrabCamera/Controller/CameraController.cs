using UnityEngine;

namespace Core.Scripts.GrabCamera.Controller
{
    public class CameraController : MonoBehaviour, ICameraController
    {
        public Camera Camera { get; private set; }
        
        [Header("Limits")]
        [SerializeField] private GameObject _limitMin;
        [SerializeField] private GameObject _limitMax;

        private void Awake()
        {
            Camera = Camera.main;
        }
        
        public static Vector3 GetRayIntersectionWithYPlane(Ray ray, float y)
        {
            if (ray.direction.y.Equals(0)) return ray.GetPoint(ray.origin.y);
            var t = (y - ray.origin.y) / ray.direction.y;
            return ray.GetPoint(t);
        }

        public void CheckCameraPositionLimits()
        {
            var position = transform.position;
            var viewportCenter = new Vector3(0.5f, 0.5f, 0);
            var ray = Camera.ViewportPointToRay(viewportCenter);
            var intersectionPoint = GetRayIntersectionWithYPlane(ray, 0);
            var offset = intersectionPoint - position;
            offset.y = 0;

            var newViewportCenter = position + offset;
            var limitMin = _limitMin.transform.position;
            var limitMax = _limitMax.transform.position;

            newViewportCenter.x = Mathf.Clamp(newViewportCenter.x, limitMin.x, limitMax.x);
            newViewportCenter.z = Mathf.Clamp(newViewportCenter.z, limitMin.z, limitMax.z);

            position = newViewportCenter - offset;
            transform.position = position;
        }
    }
}
