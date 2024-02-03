using System;
using GameCore.ServiceLocator;
using UnityEngine;

namespace PlayerCore.HealthSystem
{
    class PlayerHealthService : IPlayerHealthService, IService
    {
        private PlayerHealthData _playerHealthData;
        public event Action OnPlayerDied;
        private float _startHp = 2;
        private bool _availableHealth;

        public void Initialize(PlayerHealthData playerHealthData)
        {
            _playerHealthData = playerHealthData;
            _availableHealth = true;
        }
        public void SetPaused(bool isPaused)
        {
            _availableHealth = !isPaused;
        }

        public void AddHealth(float heal)
        {
            _playerHealthData.PlayerHp += heal;
        }

        public void AddDamage(float damage)
        {
            if (_availableHealth)
            {
                _playerHealthData.PlayerHp -= damage;
                if (_playerHealthData.PlayerHp <= 0f)
                {
                    PlayerDied();
                }
            }
            Debug.Log($"Player hp: {_playerHealthData.PlayerHp}");
        }

        public void SetHealthStartState()
        {
            _playerHealthData.PlayerHp = _startHp;
        }

        public void EnableDamage(bool isDamageAllowed)
        {
            throw new NotImplementedException();
        }

        public bool IsPlayerDead()
        {
            return _playerHealthData.IsPlayerDead;
        }

        public void PlayerDied()
        {
            _playerHealthData.IsPlayerDead = true;
            OnPlayerDied?.Invoke();
        }
    }
}