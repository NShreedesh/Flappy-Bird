using System;
using Manager;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        [Header("Movement Values")]
        [SerializeField]
        private float moveSpeed;

        [Header("Position Values")]
        [SerializeField]
        private float minYPosition = -1;
        [SerializeField]
        private float maxYPosition = 2;

        [SerializeField]
        private float destroyXPosition = -5f;

        private void OnEnable()
        {
            InvokeRepeating(nameof(DestroyObstacle), 5, 1);
        }

        private void OnDisable()
        {
            CancelInvoke();
        }

        private void Update()
        {
            if(GameManager.Instance.IsPlayerDead) return;
            transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
        }

        private void DestroyObstacle()
        {
            if (transform.position.x < destroyXPosition)
            {
                Destroy(gameObject);
            }
        }

        public void SetRandomPosition()
        {
            transform.position = new Vector3(transform.position.x, Random.Range(minYPosition, maxYPosition), transform.position.z);
        }
    }
}
