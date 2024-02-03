using FPSController.CameraController;
using FPSController.FirstPersonController;
using PlayerCore.HealthSystem;
using UnityEngine;

namespace PlayerCore
{
    [CreateAssetMenu(fileName = "PlayerServiceProvider", menuName = "PlayerCoreMechanics/PlayerServiceProvider")]
    public class PlayerServiceProvider : ScriptableObject
    {
        // здесь только хранится ничего не создается
       [SerializeField] private FirstPersonController fpsController;
       [SerializeField] private CameraController cameraController;
       [SerializeField] private PlayerData playerData;
       

        public FirstPersonController FPSController => fpsController; 
        public CameraController CameraController => cameraController;
        public PlayerData PlayerData => playerData;
    }
}