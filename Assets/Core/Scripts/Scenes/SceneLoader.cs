using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Scripts.Scenes
{
    public class SceneLoader : MonoBehaviour
    {
        private void Awake()
        {
            LoadNewScene("DorianDeVillele");
        }

        public static void LoadNewScene(string sceneName)
        {
            SceneManager.LoadScene($"Assets/Scenes/{sceneName}.unity");
        }
    }
}
