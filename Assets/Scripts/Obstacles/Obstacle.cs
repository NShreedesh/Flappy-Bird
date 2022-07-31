using System;
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

        private void OnEnable()
        {
            Destroy(gameObject, 6);
        }

        private void Update()
        {
            transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
        }

        public void SetRandomPosition()
        {
            transform.position = new Vector3(transform.position.x, Random.Range(minYPosition, maxYPosition), transform.position.z);
        }
    }
}
