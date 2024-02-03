using UnityEngine;

namespace GameCore.Contexts.LevelContext.SpawnPlayer
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
        
        public void SpawnPlayer()
        {
            Instantiate(playerPrefab, transform);
        }
    }
}