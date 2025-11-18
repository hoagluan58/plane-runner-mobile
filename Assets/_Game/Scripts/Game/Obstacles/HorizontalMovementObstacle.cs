using UnityEngine;

namespace PlaneRunner
{
    public class HorizontalMovementObstacle : MonoBehaviour
    {
        [Header("Horizontal Movement")]
        [SerializeField] private Vector2 _xRange = new Vector2(-18f, 18f);
        [SerializeField] private float _horizontalSpeed = 2f;

        private float _phaseOffset;

        private void Start()
        {
            _phaseOffset = Random.Range(0f, 10f);
        }

        private void Update()
        {
            float t = Mathf.Sin((Time.time + _phaseOffset) * _horizontalSpeed);
            float x = Mathf.Lerp(_xRange.x, _xRange.y, (t + 1f) / 2f);

            Vector3 pos = transform.position;
            pos.x = x;
            transform.position = pos;
        }
    }
}
