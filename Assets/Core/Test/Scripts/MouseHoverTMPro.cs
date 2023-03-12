using Core.Globals.Cursors;
using Core.GrabCamera.Scripts;
using TMPro;
using UnityEngine;

namespace Core.Test.Scripts
{
    public class MouseHoverTMPro : MonoBehaviour
    {
        [SerializeField] private string SceneName = "House";
        [SerializeField] private string CamPositionName;

        private Camera _camera;
        private Vector3 _cameraWorldPosition;
        
        private void Awake()
        {
            _camera = Camera.main;
        }
        
        private TextMeshProUGUI textMeshPro;

        private void Start()
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
        }

        private void OnMouseEnter()
        {
            textMeshPro.color = new Color32(0, 139, 248, 255);
        }

        private void OnMouseExit()
        {
            textMeshPro.color = new Color32(248, 248, 248, 255);
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorHand);
        }

        private void OnMouseOver()
        {
            if (!GlobalCursors.Instance.Ecursor.Equals(GlobalCursors.ECursor.Hand)) return;
            
            GlobalCursors.SetHandCursor(GlobalCursors.Instance.CursorClicHouse, GlobalCursors.ECursor.Clic);
        }

        private void OnMouseDown()
        {
            SceneLoader.LoadNewScene(_camera.transform, SceneName, CamPositionName);
        }
    }
}
