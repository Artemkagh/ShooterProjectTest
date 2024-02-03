using PlayerCore.HealthSystem;
using UnityEngine;

namespace PlayerCore
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "Player/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private PlayerHealthData playerHealthData;

        public PlayerHealthData PlayerHealthData => playerHealthData;

        public void ResetData() 
        {
            playerHealthData.ResetData();
        }
        
        
    }
}