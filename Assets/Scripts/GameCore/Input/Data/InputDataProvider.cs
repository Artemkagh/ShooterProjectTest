using UnityEngine;

namespace GameCore.Input.Data
{
    [CreateAssetMenu(fileName = "InputDataProvider", menuName = "PlayerInputData/InputDataProvider", order = 1)]
    public class InputDataProvider : ScriptableObject
    {
        [Space, Header("Input Data")] 
        [SerializeField] private CameraInputData cameraInputData;
        [SerializeField] private MovementInputData movementInputData;
        [SerializeField] private NonGameplayInputData nonGameplayInputData;

        public CameraInputData CameraInputData => cameraInputData;

        public MovementInputData MovementInputData => movementInputData;

        public NonGameplayInputData NonGameplayInputData => nonGameplayInputData;
    }
}