using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

[InitializeOnLoad]
public class AlwaysStartSceneEditor
{
    private const string StartScenePath = "Assets/Scenes/PersistentScene.unity";
    private static string _previousScenePath;

    static AlwaysStartSceneEditor()
    {
        EditorApplication.playModeStateChanged += PlayModeStateChanged;
        EditorSceneManager.sceneOpened += OnSceneOpened;
    }

    private static void PlayModeStateChanged(PlayModeStateChange state)
    {
        if (!state.Equals(PlayModeStateChange.ExitingEditMode)) return;
        _previousScenePath = SceneManager.GetActiveScene().path;

        if (_previousScenePath == StartScenePath) return;
        EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        EditorSceneManager.OpenScene(StartScenePath, OpenSceneMode.Single);
    }

    private static void OnSceneOpened(Scene scene, OpenSceneMode mode)
    {
        if (mode != OpenSceneMode.Single || scene.path != StartScenePath || string.IsNullOrEmpty(_previousScenePath) || EditorApplication.isPlaying) return;
        
        EditorSceneManager.OpenScene(_previousScenePath, OpenSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByPath(_previousScenePath));
        EditorSceneManager.sceneOpened -= OnSceneOpened;
    }
}
