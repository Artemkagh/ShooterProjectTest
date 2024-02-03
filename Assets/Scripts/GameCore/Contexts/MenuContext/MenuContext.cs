using GameCore.SceneLoading;
using UI;
using UnityEngine;

namespace GameCore.Contexts.MenuContext
{
    public class MenuContext : MonoBehaviour
    {
        [SerializeField] private MainMenu mainMenu;
        
        void Awake()
        {
            RegisterListeners();
        }

        private void RegisterListeners()
        {
            mainMenu.PlayBtn.onClick.AddListener(LoadGameScene);
            mainMenu.QuitBtn.onClick.AddListener(QuitApp);
        }

        private void LoadGameScene()
        {
            ServiceLocator.ServiceLocator.GetService<SceneLoaderService>().LoadGame();
            //var operation = ServiceLocator.GetService<SceneLoaderService>().LoadGame();
            //operation.completed += UnloadMainMenu;
        }

        // private void UnloadMainMenu(AsyncOperation obj)
        // {
        //     ServiceLocator.GetService<SceneLoaderService>().UnloadMainMenu();
        // }
        private void QuitApp()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            // Application.Quit()
        }

        private void OnDestroy()
        {
            UnRegisterListeners();
        }

        private void UnRegisterListeners()
        {
            mainMenu.PlayBtn.onClick.RemoveListener(LoadGameScene);
            mainMenu.QuitBtn.onClick.RemoveListener(QuitApp);
        }
    }
}