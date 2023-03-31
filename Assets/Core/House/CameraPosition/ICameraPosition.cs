using UnityEngine;

namespace Core.House.CameraPosition
{
    public interface ICameraPosition
    {
        Vector3 GetPosition();
        Quaternion GetRotation();
    }
}