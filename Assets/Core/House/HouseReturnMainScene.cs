using Core.GrabCamera.Scripts;
using UnityEngine;

namespace Core.House
{
    public class HouseReturnMainScene : MonoBehaviour
    {
        #region Events

        private void OnMouseEnter()
        {
            SceneLoader.LoadNewScene("DorianDeVillele");
        }

        #endregion
    }
}