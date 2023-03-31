using Core.Globals;
using Core.GrabCamera.Scripts;
using UnityEngine;

namespace Core.Test.Scripts
{
    public class TestReturnFirstScene : MonoBehaviour
    {
        #region Events

        private void OnMouseDown()
        {
            SceneLoader.Instance.LoadNewScene("DorianDeVillele");
        }

        #endregion
    }
}
