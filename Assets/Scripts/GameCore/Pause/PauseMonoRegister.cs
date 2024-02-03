using GameCore.Input;
using PlayerCore;
using PlayerCore.HealthSystem;
using UnityEngine;

namespace GameCore.Pause
{
    public class PauseMonoRegister : MonoBehaviour
    {
        private IPauseService _pauseService;
        private PlayerServiceProvider _playerServiceProvider;
        private IPlayerHealthService _healthService;
        private IPlayerInputService _inputService;
        
        
        private void Construct(IPauseService pauseService, PlayerServiceProvider serviceProvider,
            IPlayerHealthService healthService, IPlayerInputService inputService)
        {
            _healthService = healthService;
            _playerServiceProvider = serviceProvider;
            _pauseService = pauseService;
            _inputService = inputService;
        }

        private void Start()
        {
            RegisterServices();
        }

        private void OnDestroy()
        {
            UnregisterServices();
        }

        private void RegisterServices()
        {
            _pauseService.Register(_playerServiceProvider.FPSController);
            _pauseService.Register(_inputService);
            _pauseService.Register(_playerServiceProvider.CameraController);
            _pauseService.Register(_healthService);
        }

        private void UnregisterServices()
        {
            _pauseService.UnRegister(_playerServiceProvider.FPSController);
            _pauseService.UnRegister(_inputService);
            _pauseService.UnRegister(_playerServiceProvider.CameraController);
            _pauseService.UnRegister(_healthService);
        }
    }
}