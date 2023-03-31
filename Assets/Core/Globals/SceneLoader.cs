using System.Collections;
using Core.House;
using Core.House.CameraPosition;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.Globals
{
    public class SceneLoader : MonoBehaviour
    {
        #region Statements
        
        public static SceneLoader Instance { get; private set; }
        public static CameraPositionName CamPositionName { get; private set; }
        
        private static readonly int START = Animator.StringToHash("Start");
        private static readonly int END = Animator.StringToHash("End");
        
        private Animator _animator;

        private void Awake()
        {
            if (Instance is null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        private void Start()
        {
            _animator = transform.Find("CanvasTransitions").Find("Image").GetComponent<Animator>();
        }

        #endregion

        #region Functions

        private static void SetCamPositionName(CameraPositionName cameraPositionName) => CamPositionName = cameraPositionName;

        public void LoadNewScene(string scene)
        {
            StartCoroutine(LoadScene(scene));
        }

        public void LoadNewScene(string scene, CameraPositionName camPositionName)
        {
            SetCamPositionName(camPositionName);
            LoadNewScene(scene);
        }

        #endregion

        #region Coroutines

        private IEnumerator LoadScene(string scene)
        {
            var currentScene = SceneManager.GetActiveScene().name;
            
            _animator.SetTrigger(START);
            yield return new WaitForSeconds(0.35f);
 
            SceneManager.LoadSceneAsync(scene);

            while ($"{SceneManager.GetActiveScene().name}".Equals($"{currentScene}"))
            {
                yield return new WaitForSeconds(0.1f);
            }
            
            yield return new WaitForSeconds(0.1f);
            _animator.SetTrigger(END);
        }

        #endregion
    }
}
