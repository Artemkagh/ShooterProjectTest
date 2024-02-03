using UnityEngine;

namespace OldMovment
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] private InputData _inputData;
        private Vector2 _lookaround;
        private float _lookUpDownSpeed = 25f;

        private void LookUpDown()
        {
            _lookaround.y += _inputData.LookUpDown * _lookUpDownSpeed;
            _lookaround.y = Mathf.Clamp( _lookaround.y, -50.0f, 50.0f);
            transform.localRotation = Quaternion.Euler(-_lookaround.y,0, 0);
        }

        void Update()
        {
            LookUpDown();
        }
    }
}
