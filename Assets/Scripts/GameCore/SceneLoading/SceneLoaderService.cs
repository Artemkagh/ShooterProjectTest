using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameCore.SceneLoading
{
    public class SceneLoaderService : ISceneLoaderService
    {
        public AsyncOperation LoadMainMenu()
        {
            return SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
        }

        public AsyncOperation UnloadMainMenu()
        {
            return SceneManager.UnloadSceneAsync("MainMenu");
        }

        public AsyncOperation LoadGame()
        {
            return SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Single);
        }

        public AsyncOperation UnloadGame()
        {
            return SceneManager.UnloadSceneAsync("GameScene");
        }
    }
}
