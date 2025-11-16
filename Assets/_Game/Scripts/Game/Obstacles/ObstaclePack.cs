using UnityEngine;

namespace PlaneRunner
{
    public class ObstaclePack : MonoBehaviour
    {
        public Transform EndPoint;
        public float MoveSpeed = 0;

        private void Update()
        {
            transform.position += GameManager.I.GameSpeed * Time.deltaTime * Vector3.back;
            if (transform.position.z < -50)
                Destroy(gameObject);
        }
    }
}
