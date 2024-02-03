using System;
using GameCore.Input.Data;
using GameCore.ServiceLocator;
using UnityEngine;

namespace GameCore.Input
{
    public class PlayerInputService : IPlayerInputService, IService
    {
        private InputDataProvider _inputData;
        public event Action OnPauseClicked;
        private bool _isInputActive;

        
        public void Initialize(InputDataProvider inputDataProvider)
        {
            _inputData = inputDataProvider;
            _isInputActive = true;
            ResetInput();
        }
        
        public void UpdateInput()
        {
            UpdateNonGameplayInputData();
            if (!_isInputActive) return;
            UpdateCameraInput();
            UpdateMovementInputData();
        }


        public void SetInputActive(bool state)
        {
            if (state==false) ResetInput();
            _isInputActive = state;
        }

        private void UpdateNonGameplayInputData()
        {
            _inputData.NonGameplayInputData.PauseClicked = UnityEngine.Input.GetKeyDown(KeyCode.O);
            if (_inputData.NonGameplayInputData.PauseClicked)
            {
                OnPauseClicked?.Invoke();
            }
        }
       
        private void UpdateCameraInput()
        {
            _inputData.CameraInputData.InputVectorX = UnityEngine.Input.GetAxis("Mouse X");
            _inputData.CameraInputData.InputVectorY = UnityEngine.Input.GetAxis("Mouse Y");

            _inputData.CameraInputData.ZoomClicked = UnityEngine.Input.GetMouseButtonDown(2);
            _inputData.CameraInputData.ZoomReleased = UnityEngine.Input.GetMouseButtonUp(2);
        }

        private void UpdateMovementInputData()
        {
            _inputData.MovementInputData.InputVectorX = UnityEngine.Input.GetAxisRaw("Horizontal");
            _inputData.MovementInputData.InputVectorY = UnityEngine.Input.GetAxisRaw("Vertical");

            _inputData.MovementInputData.RunClicked = UnityEngine.Input.GetKeyDown(KeyCode.LeftShift);
            _inputData.MovementInputData.RunReleased = UnityEngine.Input.GetKeyUp(KeyCode.LeftShift);

            if ( _inputData.MovementInputData.RunClicked)
                _inputData.MovementInputData.IsRunning = true;

            if ( _inputData.MovementInputData.RunReleased)
                _inputData.MovementInputData.IsRunning = false;

            _inputData.MovementInputData.JumpClicked = UnityEngine.Input.GetKeyDown(KeyCode.Space);
            _inputData.MovementInputData.CrouchClicked = UnityEngine.Input.GetKeyDown(KeyCode.LeftControl);
            _inputData.MovementInputData.LeftClicked = UnityEngine.Input.GetKeyDown(KeyCode.Mouse0);
            _inputData.MovementInputData.ReloadClicked = UnityEngine.Input.GetKeyDown(KeyCode.R);
            _inputData.MovementInputData.RespawnWallClicked = UnityEngine.Input.GetKeyDown(KeyCode.Y);
        }
        

        public void ResetInput()
        {
            _inputData.CameraInputData.ResetInput();
            _inputData.MovementInputData.ResetInput();
            _inputData.NonGameplayInputData.ResetInput();
        }

        public void SetPaused(bool isPaused)
        {
            SetInputActive(!isPaused);
        }
    }
}