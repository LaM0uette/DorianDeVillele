using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core.GrabCamera.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        #region Statements
        
        public static SceneLoader Instance { get; private set; }
        public static string CamPositionName { get; private set; }

        private static readonly int START = Animator.StringToHash("Start");
        private static readonly int END = Animator.StringToHash("End");
        
        private Animator _animator;

        private void Awake()
        {
            if (Instance == null)
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

        private static void SetCamPositionName(string camPositionName) => CamPositionName = camPositionName;

        public void LoadNewScene(string scene)
        {
            StartCoroutine(LoadScene(scene));
        }

        public void LoadNewScene(string scene, string camPositionName)
        {
            SetCamPositionName(camPositionName);
            LoadNewScene(scene);
        }

        #endregion

        #region Coroutines

        private IEnumerator LoadScene(string scene)
        {
            _animator.SetTrigger(START);
            
            yield return new WaitForSeconds(0.8f);
            
            _animator.SetTrigger(END);
            
            SceneManager.LoadScene(scene);
        }

        #endregion
    }
}
