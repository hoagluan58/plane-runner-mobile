using NFramework;
using UnityEngine;

namespace PlaneRunner
{
    public class CameraController : SingletonMono<CameraController>
    {
        private float _shakeTimer;
        private float _shakeRadius = 1;
        [HideInInspector]
        public bool _shakeEnabled = true;

        private Vector3 _lerpedPosition;
        private Quaternion _lerpedRotation;
        Vector3 _camOffset = Vector3.zero;
        private Camera _camera;
        private bool _isUpdate = false;

        public void EnableUpdate(bool isEnable) => _isUpdate = isEnable;

        private void Start()
        {
            _lerpedPosition = transform.position;
            _lerpedRotation = transform.rotation;

            _shakeEnabled = true;
        }

        private void Update()
        {
            if (!_isUpdate)
            {
                return;
            }

            _shakeTimer -= Time.deltaTime;
            if (_shakeTimer <= 0)
                _shakeTimer = 0;
        }

        private void LateUpdate()
        {
            if (!_isUpdate) return;

            Vector3 finalPosition = Vector3.zero;
            Quaternion finalRotation = Quaternion.identity;

            Vector3 ShakeOffset = Vector3.zero;
            float shakeSin = Mathf.Cos(30 * Time.time) * Mathf.Clamp(_shakeTimer, 0, 0.5f);
            float shakeCos = Mathf.Sin(50 * Time.time) * Mathf.Clamp(_shakeTimer, 0, 0.5f);
            ShakeOffset = new Vector3(_shakeRadius * shakeCos, 0, _shakeRadius * shakeSin);

            Vector3 speedShake = new Vector3(0.2f * Mathf.Cos(10 * Time.time), 0.1f * Mathf.Sin(16 * Time.time), 0);
            if (!_shakeEnabled)
            {
                speedShake = Vector3.zero;
            }
            Vector3 camPos = new Vector3(0, 20, -30);
            camPos.x += .6f * PlaneController.I.transform.position.x;
            camPos.y += .3f * PlaneController.I.transform.position.y;
            transform.position = camPos + ShakeOffset + speedShake;
        }

        public void StartShake(float t, float r)
        {
            if (_shakeTimer == 0 || _shakeRadius < r)
                _shakeRadius = r;

            _shakeTimer = t;
        }

        public Ray GetRay(Vector3 screenPosition)
        {
            Ray outputRay;
            outputRay = GetComponent<Camera>().ScreenPointToRay(screenPosition);
            return outputRay;
        }

        public Vector3 WorldToScreenPoint(Vector3 WorldPos)
        {
            Vector3 pos = GetComponent<Camera>().WorldToScreenPoint(WorldPos);
            pos.x = pos.x / Screen.width;
            pos.y = pos.y / Screen.height;

            return pos;
        }

        public Vector3 ScreenToWorldPoint(Vector3 ScreenPos)
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(ScreenPos);
            Vector3 point = ray.origin;
            point.z = 0;

            return point;
        }
    }
}
