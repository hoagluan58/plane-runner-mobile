using Sirenix.OdinInspector;
using UnityEngine;

namespace PlaneRunner
{
    public class RoadPart : MonoBehaviour
    {
        [SerializeField] private Transform _endPoint;

        [ReadOnly]
        public RoadPart NextPart;

        public Transform EndPoint => _endPoint;

        private void Update()
        {
            transform.position += GameManager.I.GameSpeed * Time.deltaTime * Vector3.back;

            if (transform.position.z < -400)
            {
                Destroy(gameObject);
            }
        }
    }
}
