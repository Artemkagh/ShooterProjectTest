using GameCore.Input.Data;
using UnityEngine;

namespace Wall
{
    public class WallSpawner : MonoBehaviour
    {
        [SerializeField] private ColorChanger wall;
        [SerializeField] private MovementInputData movementInputData;
    
        void Update()
        {   
            IsNeedShowWall();
        }

        private void IsNeedShowWall(){
            if(movementInputData.RespawnWallClicked) wall.Show();
        }
    }
}
