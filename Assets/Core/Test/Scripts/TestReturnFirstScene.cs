using Core.GrabCamera.Scripts;
using UnityEngine;

namespace Core.Test.Scripts
{
    public class TestReturnFirstScene : MonoBehaviour
    {
        private void OnMouseEnter()
        {
            SceneLoader.LoadNewScene("DorianDeVillele");
        }
    }
}
