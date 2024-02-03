using GameCore.Contexts.LevelContext.SpawnPlayer;
using GameCore.Input;
using GameCore.Input.Data;
using GameCore.Pause;
using GameCore.SceneLoading;
using PlayerCore;
using PlayerCore.HealthSystem;
using Turret;
using UI;
using UnityEngine;

namespace GameCore.Contexts.LevelContext
{
    public class LevelContext : MonoBehaviour
    {
        [SerializeField] private InputDataProvider inputDataProvider;
        [SerializeField] private PlayerServiceProvider playerServiceProvider;
        [SerializeField] private PauseMenu pauseMenu;
        [SerializeField] private DeathScreen deathScreen;
        [SerializeField] private PlayerSpawner playerSpawner;
        [SerializeField] private TurretBulletSpawner turretBulletSpawner;
        
        private PlayerInputService _playerInputService;
        private PlayerHealthService _playerHealthService;
        private PauseService _pauseService;
        private SceneLoaderService _sceneLoaderService;

        void Awake()
        {
            RegisterServices();
            RegisterPauseables();
            RegisterListeners();
            playerServiceProvider.PlayerData.ResetData();
            SpawnPlayer();
        }


        private void RegisterServices()
        {
            ServiceLocator.ServiceLocator.RegisterService<PauseService>();
            ServiceLocator.ServiceLocator.RegisterService<PlayerHealthService>();
            ServiceLocator.ServiceLocator.RegisterService<PlayerInputService>();
            
            _playerInputService = ServiceLocator.ServiceLocator.GetService<PlayerInputService>();
            _playerInputService.Initialize(inputDataProvider);
            _playerInputService.OnPauseClicked += PausePressed;
            
            _playerHealthService = ServiceLocator.ServiceLocator.GetService<PlayerHealthService>();
            _playerHealthService.Initialize(playerServiceProvider.PlayerData.PlayerHealthData);
            _playerHealthService.OnPlayerDied += SetPlayerDead;

            _pauseService = ServiceLocator.ServiceLocator.GetService<PauseService>();
            _pauseService.Initialize();

            _sceneLoaderService = ServiceLocator.ServiceLocator.GetService<SceneLoaderService>();
        }

        private void RegisterPauseables()
        {
            _pauseService.Register(_playerInputService);
            _pauseService.Register(_playerHealthService);
            _pauseService.Register(pauseMenu);
            _pauseService.Register(turretBulletSpawner);
        }

        private void RegisterListeners()
        {
            pauseMenu.ContinueBtn.onClick.AddListener(ContinueGame);
            pauseMenu.QuitBtn.onClick.AddListener(QuitGame);
            deathScreen.RestartBtn.onClick.AddListener(RestartGame);
            deathScreen.QuitBtn.onClick.AddListener(QuitGame);
        }

        private void SpawnPlayer()
        {
            _playerHealthService.SetHealthStartState();
            playerSpawner.SpawnPlayer();
        }

        private void Update()
        {
            _playerInputService.UpdateInput();
        }

        private void SetPlayerDead()
        {
            deathScreen.SetDead(true);
            _playerHealthService.SetPaused(true);
            _playerInputService.SetInputActive(false);
        }

        private void PausePressed()
        {
            _pauseService.SetPaused(!_pauseService.IsPaused);
        }

        private void ContinueGame()
        {
            _pauseService.SetPaused(false);
        }

        private void RestartGame()
        {
            deathScreen.SetDead(false);
            _sceneLoaderService.LoadGame();
        }


        private void QuitGame()
        {
            _sceneLoaderService.LoadMainMenu();
        }

        private void OnDestroy()
        {
            UnRegisterServices();
            UnRegisterPauseables();
            RemoveListeners();
        }

        private void UnRegisterServices()
        {
            ServiceLocator.ServiceLocator.UnRegisterService<PauseService>();
            ServiceLocator.ServiceLocator.UnRegisterService<PlayerHealthService>();
            ServiceLocator.ServiceLocator.UnRegisterService<PlayerInputService>();
        }

        private void UnRegisterPauseables()
        {
            _pauseService.UnRegister(_playerInputService);
            _pauseService.UnRegister(_playerHealthService);
            _pauseService.UnRegister(pauseMenu);
            _pauseService.UnRegister(turretBulletSpawner);
        }
        private void RemoveListeners()
        {
            pauseMenu.ContinueBtn.onClick.RemoveListener(ContinueGame);
            pauseMenu.QuitBtn.onClick.RemoveListener(QuitGame);
            deathScreen.RestartBtn.onClick.RemoveListener(RestartGame);
            deathScreen.QuitBtn.onClick.RemoveListener(QuitGame);
            _playerHealthService.OnPlayerDied -= SetPlayerDead;
            _playerInputService.OnPauseClicked -= PausePressed;
            
        }
    }
}