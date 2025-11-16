using NFramework;
using UnityEngine;

namespace PlaneRunner
{
    public class PlaneController : SingletonMono<PlaneController>
    {
        [SerializeField] private Vector2 _angle = Vector2.zero;
        [SerializeField] private Transform _base;
        [SerializeField] private Vector2 _turnSpeed = Vector2.zero;
        [SerializeField] private GameObject _explodeParticle;

        private bool _isUpdate = false;

        public void EnableUpdate(bool isEnable) => _isUpdate = isEnable;

        private void Update()
        {
            if (!_isUpdate) return;

            float InputX = 0, InputY = 0;
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                InputX = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                InputX = 1;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                InputY = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                InputY = -1;
            }

            Vector3 movement = 40 * Time.deltaTime * new Vector3(InputX, InputY, 0);

            _angle.x = Mathf.Lerp(_angle.x, 60.0f * InputX, 5 * Time.deltaTime);
            _angle.y = Mathf.Lerp(_angle.y, 20.0f * InputY, 5 * Time.deltaTime);

            _base.localRotation = Quaternion.Euler(-1f * _angle.y, 0, -_angle.x);

            transform.position += movement;

            Vector3 pos = transform.position;
            pos.y = Mathf.Clamp(pos.y, 8, 30);
            pos.x = Mathf.Clamp(pos.x, -18, 18);
            pos.z = 0;
            transform.position = pos;

            Collider[] hits = Physics.OverlapSphere(transform.position, 2.5f);
            foreach (Collider hit in hits)
            {
                if (hit.gameObject == gameObject)
                    continue;


                if (_explodeParticle != null)
                {
                    GameObject obj = Instantiate(_explodeParticle);
                    obj.transform.position = transform.position;
                }

                GameManager.I.GameOver();
                gameObject.SetActive(false);
                EnableUpdate(false);
                break;
            }
        }
    }
}
