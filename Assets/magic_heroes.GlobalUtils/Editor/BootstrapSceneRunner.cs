using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Threading.Tasks;

namespace magic_heroes.GlobalUtils.Editor
{
    public class BootstrapSceneRunner : EditorWindow
    {
        private static Task _cachedDelay = Task.Delay(100);
        
        [MenuItem("Play/PlayMe _%h")]
        public static void RunMainScene()
        {
            if (EditorApplication.isPlaying)
            {
                EditorApplication.isPlaying = false;
                OpenLastScene();
            }
            else
            {
                var currentSceneName = EditorApplication.currentScene;
                File.WriteAllText(".lastScene", currentSceneName);

                EditorApplication.OpenScene("Assets/magic_heroes.Client/Scenes/Bootstrap.unity");
                EditorApplication.isPlaying = true;
            }
        }

        private static async void OpenLastScene()
        {
            while (EditorApplication.isPlaying) 
                await _cachedDelay;
            var lastScene = await File.ReadAllTextAsync(".lastScene");
            EditorApplication.OpenScene(lastScene);
        }

    }
}