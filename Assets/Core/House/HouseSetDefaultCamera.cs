using Core.GrabCamera.Scripts;
using UnityEngine;

namespace Core.House
{
    public class HouseSetDefaultCamera : MonoBehaviour
    {
        #region Statements

        [SerializeField ] private GameObject DorianHouse;
        
        private void Start()
        {
            var go = GetGoByName(SceneLoader.CamPositionName);
            
            var cameraTransform = transform;
            cameraTransform.position = go.transform.position;
            cameraTransform.rotation = go.transform.rotation;
        }

        #endregion
        
        #region Functions

        private GameObject GetGoByName(string goName)
        {
            return goName switch
            {
                "DorianHouse" => DorianHouse,
                _ => DorianHouse
            };
        }

        #endregion
    }
}
