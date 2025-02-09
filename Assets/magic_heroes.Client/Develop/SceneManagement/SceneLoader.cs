using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace magic_heroes.Client.SceneManagement
{
    public class SceneLoader : MonoBehaviour
    {
        public static SceneLoader instance { get; private set; }

        [Header("UI Elements")] [SerializeField]
        private GameObject loadingScreen;

        [SerializeField] private Image progressBar;

        private void Awake()
        {
            if (instance is null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public async void LoadScene(SceneName sceneName)
        {
            progressBar.fillAmount = 0;
            //if current scene name is equals to sceneName then its reloading scene instead of loading
            if (GetActiveSceneName().Equals(sceneName.ToString()))
            {
                if (!loadingScreen.activeSelf)
                    loadingScreen.SetActive(true);
                var emptyScene = SceneManager.LoadSceneAsync(SceneName.Empty.ToString());
                emptyScene.allowSceneActivation = false;
                do
                {
                    await Task.Delay(100);
                } while (emptyScene?.progress < 0.9f);
                emptyScene.allowSceneActivation = true;
            }

            //load scene
            var scene = SceneManager.LoadSceneAsync(sceneName.ToString());
            if (scene is not null)
            {
                scene.allowSceneActivation = false;
            }
            else
            {
                Debug.LogWarning($"Scene {sceneName} is not loaded");
                return;
            }

            if (!loadingScreen.activeSelf)
                loadingScreen.SetActive(true);

            //loading scene progress
            do
            {
                await Task.Delay(100);
                progressBar.fillAmount = scene.progress;
            } while (scene.progress < 0.9f);

            scene.allowSceneActivation = true;
            loadingScreen.SetActive(false);
        }

        public static string GetActiveSceneName() => SceneManager.GetActiveScene().name;

        //name each scene same as scene existing in project
        public enum SceneName
        {
            Bootstrap,
            Empty,
            Battle
        }
    }
}