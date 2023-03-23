using Core.GrabCamera.Scripts;
using UnityEngine;

namespace Core.House
{
    public class HouseReturnMainScene : MonoBehaviour
    {
        #region Events

        private void OnMouseUp()
        {
            SceneLoader.Instance.LoadNewScene("DorianDeVillele");
        }

        #endregion
    }
}