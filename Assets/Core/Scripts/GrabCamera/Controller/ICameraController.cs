using UnityEngine;

namespace Core.Scripts.GrabCamera
{
    public interface ICameraController
    {
        Camera Camera { get; }
        void CheckCameraPositionLimits();
    }
}
