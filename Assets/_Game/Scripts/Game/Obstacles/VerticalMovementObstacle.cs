using UnityEngine;

namespace PlaneRunner
{
    public class VerticalMovementObstacle : MonoBehaviour
    {
        [Header("Vertical Movement")]
        [SerializeField] private Vector2 _yRange = new Vector2(8f, 30f);
        [SerializeField] private float _verticalSpeed = 2f;

        private float _phaseOffset;

        private void Start()
        {
            _phaseOffset = Random.Range(0f, 10f);
        }

        private void Update()
        {
            float t = Mathf.Sin((Time.time + _phaseOffset) * _verticalSpeed);
            float y = Mathf.Lerp(_yRange.x, _yRange.y, (t + 1f) / 2f);

            Vector3 pos = transform.position;
            pos.y = y;
            transform.position = pos;
        }
    }
}
