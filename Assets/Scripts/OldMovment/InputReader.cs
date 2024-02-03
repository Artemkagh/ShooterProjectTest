using UnityEngine;

namespace OldMovment
{
    public  class InputReader : MonoBehaviour
    {
        [SerializeField] private InputData _inputData;
    
        void Update()
        {  
            ReadInput();
        }

        public void ReadInput()
        { 
            _inputData.Force = new Vector3(0, 0, 0);
            _inputData.ReloadClicked = false;
            _inputData.LeftClicked = false;
            _inputData.SpaceClicked = false; 
        
            _inputData.ReloadClicked = Input.GetKeyDown(KeyCode.R);
            _inputData.LeftClicked = Input.GetKeyDown(KeyCode.Mouse0);
            _inputData.SpaceClicked = Input.GetKeyDown(KeyCode.Space);
            _inputData.LookAround = Input.GetAxis("Mouse X");
            _inputData.LookUpDown = Input.GetAxis("Mouse Y");
            _inputData.ForceX = Input.GetAxisRaw("Horizontal"); 
            _inputData.ForceZ = Input.GetAxisRaw("Vertical");

        }
    }
}
