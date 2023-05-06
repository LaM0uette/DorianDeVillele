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
        if (!state.Equals(PlayModeStateChange.ExitingEditMode))
        {
            if (state.Equals(PlayModeStateChange.EnteredEditMode))
            {
                CleanupLoadedScenes();
            }
        }
        else
        {
            _previousScenePath = SceneManager.GetActiveScene().path;

            if (_previousScenePath.Equals(StartScenePath)) return;
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            EditorSceneManager.OpenScene(StartScenePath, OpenSceneMode.Single);
        }
    }

    private static void OnSceneOpened(Scene scene, OpenSceneMode mode)
    {
        if (!mode.Equals(OpenSceneMode.Single) || !scene.path.Equals(StartScenePath) || string.IsNullOrEmpty(_previousScenePath) || EditorApplication.isPlaying) return;

        EditorSceneManager.OpenScene(_previousScenePath, OpenSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneByPath(_previousScenePath));
        EditorSceneManager.sceneOpened -= OnSceneOpened;
    }

    private static void CleanupLoadedScenes()
    {
        var persistentScene = SceneManager.GetSceneByPath(StartScenePath);
        if (persistentScene.IsValid() && persistentScene.isLoaded)
        {
            EditorSceneManager.CloseScene(persistentScene, true);
        }
    }
}
