using GameCore.Pause;
using Projectile;
using UnityEngine;

namespace Turret
{
    public class TurretBulletSpawner : MonoBehaviour, IPauseable
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private BulletConfig bulletConfig;
        private int _damage;
        private Color _bulletColor;
        private float _timeRemaining = 2;
        private bool _isPaused = false;


        void Awake()
        {
            ApplyConfig();
        }

        void Update()
        {
            if (!_isPaused) ShotTimer();
        }

        private void ShotTimer()
        {
            if (_timeRemaining > 0)
            {
                _timeRemaining -= Time.deltaTime;
            }
            else
            {
                Shot();
                _timeRemaining = 2;
            }
        }


        private void ApplyConfig(){
            _bulletColor = bulletConfig.BulletColor;
            _damage = bulletConfig.Damage;
        }
        

        private void Shot(){
            var bullet = Instantiate(bulletPrefab, transform.position,  transform.rotation);
            bullet.Color = _bulletColor;
            bullet.Damage = _damage;
        }

        public void SetPaused(bool isPaused)
        {
            _isPaused = isPaused;
        }
    }
}