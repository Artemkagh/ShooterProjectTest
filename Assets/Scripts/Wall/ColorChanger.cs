using Projectile;
using UnityEngine;

namespace Wall
{
    public class ColorChanger : MonoBehaviour
    {
        private int _hp = 9;
        private Renderer _renderer;

        public void Show()
        {
            gameObject.SetActive(true);
            _renderer.material.color = Color.white;
            _hp = 9;
        }

        void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("BulletTag")){
                Bullet bullet = collision.gameObject.GetComponent<Bullet>();
                TakeDamage(bullet.Damage);
                TakeColor(bullet.Color);
                Debug.Log($"Wall hp: {_hp}");
            } 
        }

        private void TakeDamage(int damage)
        {
            _hp -= damage;
            CheckHp();
        }

        private void TakeColor(Color color)
        {
            _renderer.material.color = color;
        }

        private void CheckHp(){
            if(_hp <= 0) gameObject.SetActive(false);
        }

    }
}
