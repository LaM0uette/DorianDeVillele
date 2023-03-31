using System.Collections.Generic;
using System.Linq;
using Core.Globals;
using UnityEngine;

namespace Core.House.CameraPosition
{
    public class HouseSetCameraPosition : MonoBehaviour
    {
        #region Statements

        [SerializeField] private GameObject ParentGameObject;
        
        private List<CameraPosition> _cameraPositions = new();

        private void Awake()
        {
            var goChildCount = ParentGameObject.transform.childCount;
            for (var i = 0; i < goChildCount; i++) AddCameraPosition(i);
        }

        private void Start()
        {
            var gameObj = GetCameraPositionByName(SceneLoader.CamPositionName);
            
            var cameraTransform = transform;
            cameraTransform.position = gameObj.transform.position;
            cameraTransform.rotation = gameObj.transform.rotation;
        }

        #endregion
        
        #region Functions

        private void AddCameraPosition(int i)
        {
            var childGameObject = ParentGameObject.transform.GetChild(i).gameObject;
            _cameraPositions.Add(new CameraPosition(childGameObject, (CameraPositionName) i));
        }

        private GameObject GetCameraPositionByName(CameraPositionName cameraPositionName)
        {
            foreach (var cameraPosition in _cameraPositions.Where(cp => cp.CameraPositionName.Equals(cameraPositionName)))
            {
                return cameraPosition.GameObjectCamera;
            }

            return _cameraPositions.First().GameObjectCamera;
        }

        #endregion
    }
}
