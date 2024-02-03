using UnityEngine;

namespace OldMovment
{
    public class CapsuleMover : MonoBehaviour
    {   
        [SerializeField] private Rigidbody _rb;
        [SerializeField] private InputData _inputData;
        [SerializeField] [Range(10,35)] private float _movementSpeed = 15f;
        [SerializeField] [Range(10,35)] private float _maxVelocity = 15f;
        [SerializeField] [Range(15,35)] private float _lookAroundSpeed = 25f;
        private Vector3 _forceFromInput;
        private float _lookAround = 0f;

        void Awake() 
        {
            _rb.constraints = RigidbodyConstraints.FreezeRotation;
        }

        void Update()
        {   
            ApplyMove(); 
        }

        void FixedUpdate()
        {   
            Move();
        }

        private void Move()
        {
            if (_rb.velocity.magnitude >= _maxVelocity)
            {
                _rb.velocity = _rb.velocity.normalized * _maxVelocity;
            }
            transform.rotation = Quaternion.Euler(0, _lookAround, 0);
            _rb.AddRelativeForce (_forceFromInput,  ForceMode.Impulse);
        }

        private void ApplyMove(){
            _lookAround = _inputData.LookAround * _lookAroundSpeed;
            _forceFromInput = _inputData.Force * (_movementSpeed * Time.fixedDeltaTime);
        }
    
    }
}