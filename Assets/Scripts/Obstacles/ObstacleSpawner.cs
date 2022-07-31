using Manager;
using Unity.Mathematics;
using UnityEngine;

namespace Obstacles
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [Header("Obstacles Info")]
        [SerializeField]
        private Obstacle[] obstacles;

        [Header("Obstacles Spawn Values")]
        [SerializeField]
        private float spawnTime = 3;

        private void OnEnable()
        {
            InvokeRepeating(nameof(Spawn), spawnTime, spawnTime);   
        }

        private void OnDisable()
        {
            CancelInvoke();
        }

        private void Spawn()
        {
            if(GameManager.Instance.IsPlayerDead) return;
            
            var obstacle = Instantiate(obstacles[0], transform.position, quaternion.identity, transform);
            obstacle.SetRandomPosition();
        }
    }
}
