using System.Collections.Generic;
using GameCore.Input.Data;
using UnityEngine;

namespace Projectile
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private List<BulletConfig> bulletConfigs = new List<BulletConfig>();
        [SerializeField] private MovementInputData movementInputData;
        private Renderer _renderer;
        private int _selectedBullet = 0;
        private Color _bulletColor;


        void Awake()
        {
            _renderer = GetComponent<Renderer>();
            ApplyConfig();
        }

        void Update()
        {   
            IsReloaded();
            Shot();
        }

        private void IsReloaded(){
            if(movementInputData.ReloadClicked){
                if(_selectedBullet == 2) _selectedBullet = 0;
                else _selectedBullet += 1;
                ApplyConfig();
            }
        }

        private void ApplyConfig(){

            if(bulletConfigs[_selectedBullet].Type == BulletType.RandomType){
                _bulletColor = GenerateRandomColor();
            }else _bulletColor = bulletConfigs[_selectedBullet].BulletColor;

            _renderer.material.color = _bulletColor;
        }

        private Color GenerateRandomColor(){
            return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

        private void Shot(){

            if(movementInputData.LeftClicked){
                var bullet = Instantiate(bulletPrefab, transform.position,  transform.rotation);
                bullet.Color = _bulletColor;
                bullet.Damage = bulletConfigs[_selectedBullet].Damage;
            }

        }
    }
}
