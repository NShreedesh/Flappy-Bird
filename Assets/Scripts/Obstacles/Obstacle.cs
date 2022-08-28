using Manager;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        [Header("Movement Values")]
        [SerializeField]
        private float moveSpeed = 2;

        [Header("Position Values")]
        [SerializeField]
        private float minYPosition = -1;
        [SerializeField]
        private float maxYPosition = 2;

        [SerializeField]
        private float destroyXPosition = -5f;

        private void OnDisable()
        {
            CancelInvoke();
        }

        private void Update()
        {
            if(GameManager.Instance.IsPlayerDead) return;
            transform.position += Vector3.left * (moveSpeed * Time.deltaTime);
            
            if (transform.localPosition.x <= destroyXPosition)
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
