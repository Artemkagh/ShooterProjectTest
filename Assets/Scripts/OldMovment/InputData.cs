using UnityEngine;

namespace OldMovment
{
    [CreateAssetMenu(fileName = "New InputData", menuName = "InputData", order = 1)]
    public class InputData : ScriptableObject
    {
        private Vector3 _mainForce = new Vector3(0, 0, 0); 
        private float _lookaround = 0f;
        private float _lookUpDown = 0f;
        private bool _spaceClicked = false;
        private bool _leftClicked = false;
        private bool _reloadClicked = false;
    
        // если это будет SO то не забудь сделать метод ResetData чтобы всё было по нулям при запуске сцены??????????

        public float LookAround{
            get => _lookaround;
            set => _lookaround += value;
        }

        public float LookUpDown{
            get => _lookUpDown;
            set => _lookUpDown = value;
        }

        public Vector3 Force{
            get => _mainForce;
            set =>_mainForce = value;
        }

        public float ForceX{
            set =>_mainForce.x = value;
        }

        public float ForceZ{
            set => _mainForce.z = value;
        }
    
        public bool SpaceClicked{
            get => _spaceClicked;
            set =>_spaceClicked = value;
        }

        public bool LeftClicked{
            get => _leftClicked;
            set =>_leftClicked = value;
        }

        public bool ReloadClicked{
            get => _reloadClicked;
            set =>_reloadClicked = value;
        }

 
    }
}