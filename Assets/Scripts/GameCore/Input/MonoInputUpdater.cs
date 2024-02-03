using UnityEngine;

namespace GameCore.Input
{
    public class MonoInputUpdater : MonoBehaviour
    {
        
        private IPlayerInputService _playerInputService;
        private bool _isInputActive;

        void Start()
        {
            _playerInputService = ServiceLocator.ServiceLocator.GetService<PlayerInputService>();
        }

        void Update()
        {
            _playerInputService.UpdateInput();
        }

    }
}