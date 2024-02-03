using System;
using UnityEngine;

namespace PlayerCore.HealthSystem
{
    [CreateAssetMenu(fileName = "PlayerHealthData", menuName = "PlayerCoreMechanics/HealthData")]
    public class PlayerHealthData : ScriptableObject
    {
        private float _playerHp;
        private bool _isPlayerDead;

        public float PlayerHp
        {
            get => _playerHp;
            set => _playerHp = value;
        }

        public bool IsPlayerDead
        {
            get => _isPlayerDead;
            set => _isPlayerDead = value;
        }

        public void ResetData()
        {
            _playerHp = 0f; 
            _isPlayerDead = false;
        }
    }
}