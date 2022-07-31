using Manager;
using UnityEngine;

namespace Ground
{
    public class GroundMover : MonoBehaviour
    {
        [Header("Ground Info")]
        [SerializeField]
        private GameObject[] grounds;

        [Header("Move Values")]
        [SerializeField]
        private float moveSpeed = 2;
        [SerializeField]
        private float leftGroundChangePosition = -6.4f;
        [SerializeField]
        private float groundSize = 6.71999f;

        private void Update()
        {
            if (GameManager.Instance.IsPlayerDead) return;
            
            foreach (var ground in grounds)
            {
                ground.transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0, 0));
            }

            ChangeGroundPosition();
        }

        private void ChangeGroundPosition()
        {
            if (grounds[0].transform.position.x <= leftGroundChangePosition)
            {
                grounds[0].transform.position = grounds[1].transform.position + new Vector3(groundSize, 0, 0);
            }
            else if (grounds[1].transform.position.x <= leftGroundChangePosition)
            {
                grounds[1].transform.position = grounds[0].transform.position + new Vector3(groundSize, 0, 0);
            }
        }
    }
}
