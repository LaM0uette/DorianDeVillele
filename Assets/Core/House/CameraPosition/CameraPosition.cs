using UnityEngine;

namespace Core.House.CameraPosition
{
    public class CameraPosition : ICameraPosition
    {
        public readonly GameObject GameObjectCamera;
        public readonly CameraPositionName CameraPositionName;

        public CameraPosition(GameObject gameObjectCamera, CameraPositionName cameraPositionName = CameraPositionName.DorianTemporaire)
        {
            GameObjectCamera = gameObjectCamera;
            CameraPositionName = cameraPositionName;
        }
        
        public Vector3 GetPosition() => GameObjectCamera.transform.position;
        public Quaternion GetRotation() => GameObjectCamera.transform.rotation;
    }
}