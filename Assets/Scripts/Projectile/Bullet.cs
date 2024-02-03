using GameCore.ServiceLocator;
using PlayerCore.HealthSystem;
using UnityEngine;

namespace Projectile
{
    public class Bullet : MonoBehaviour
    {
    
        [SerializeField] private Rigidbody rigidBody;
        private Renderer _renderer;
        private float _speed = 20f;
        private Color _color;
        private int _damage;

        public Color Color{
            get => _color;
            set =>_color = value;
        }

        public int Damage{
            get => _damage;
            set =>_damage = value;
        }

        void Awake()
        {
            _renderer = GetComponent<Renderer>();
        }

        void Start()
        {
            _renderer.material.color = _color;
            Destroy(gameObject, 2);
        }


        void FixedUpdate()
        {
            rigidBody.velocity = transform.up * _speed;

        } 
    
        private void OnCollisionEnter(Collision collision) 
        {
            if (collision.gameObject.CompareTag("Player")){
                ServiceLocator.GetService<PlayerHealthService>().AddDamage(Damage);
                Debug.Log( $"Bullet damage: {Damage}");
            }
            Destroy(gameObject);
        }
    }
}