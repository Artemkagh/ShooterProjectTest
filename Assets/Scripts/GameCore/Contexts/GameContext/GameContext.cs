using GameCore.Input;
using GameCore.Pause;
using GameCore.SceneLoading;
using PlayerCore.HealthSystem;
using UnityEngine;

namespace GameCore.Contexts.GameContext
{
    public class GameContext : MonoBehaviour 
    {
        private ServiceLocator.ServiceLocator _serviceLocator;

        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            ServiceLocator.ServiceLocator.Check();
            ServiceLocator.ServiceLocator.RegisterService<SceneLoaderService>();
            LoadMainMenuScene();
        }
        
        private void LoadMainMenuScene()
        {
            ServiceLocator.ServiceLocator.GetService<SceneLoaderService>().LoadMainMenu();
        }

        private void OnDestroy()
        {
            UnRegisterAll();
        }

        private void UnRegisterAll()
        {
            ServiceLocator.ServiceLocator.UnRegisterService<SceneLoaderService>();
            ServiceLocator.ServiceLocator.UnRegisterService<PauseService>();
            ServiceLocator.ServiceLocator.UnRegisterService<PlayerHealthService>();
            ServiceLocator.ServiceLocator.UnRegisterService<PlayerInputService>();
        }
    }
}
