using Core.GrabCamera.Scripts;
using UnityEngine;

namespace Core.House
{
    public class HouseReturnMainScene : MonoBehaviour
    {
        #region Events

        private void OnMouseDown()
        {
            SceneLoader.LoadNewScene("DorianDeVillele");
        }

        #endregion
    }
}