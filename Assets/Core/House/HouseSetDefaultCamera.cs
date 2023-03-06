using Core.GrabCamera.Scripts;
using UnityEngine;

namespace Core.House
{
    public class HouseSetDefaultCamera : MonoBehaviour
    {
        #region Statements

        private void Start()
        {
            transform.position = new Vector3(SceneLoader.Xposition, 2.5f, 1);
        }

        #endregion
    }
}
