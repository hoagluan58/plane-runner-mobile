using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneRunner
{
    public class WorldCreatorController : MonoBehaviour
    {
        [SerializeField] private GameObject[] _roadPartPrefabs;
        [SerializeField] private GameObject[] _objectPackPrefabs;

        [ReadOnly]
        [SerializeField] private RoadPart _lastPart;
        [ReadOnly]
        [SerializeField] private ObstaclePack _lastObstacle;
        [ReadOnly]
        [SerializeField] private List<ObstaclePack> _obstacles;

        private void Start()
        {
            _obstacles = new List<ObstaclePack>();

            RoadPart last = null;
            for (int i = 0; i < 10; i++)
            {
                GameObject obj = Instantiate(_roadPartPrefabs[0], transform);
                RoadPart p = obj.GetComponent<RoadPart>();

                if (i == 0)
                {
                    obj.transform.position = Vector3.zero;
                }
                else
                {
                    obj.transform.position = last.EndPoint.position;
                }

                if (last != null)
                {
                    last.NextPart = p;
                }
                last = p;
                _lastPart = last;
            }


            int r = Random.Range(0, _objectPackPrefabs.Length);
            GameObject obj1 = Instantiate(_objectPackPrefabs[r], transform);
            obj1.transform.position = new Vector3(0, 0, 500);
            _lastObstacle = obj1.GetComponent<ObstaclePack>();


        }

        private void Update()
        {
            if (_lastPart.transform.position.z < 200)
            {

                for (int i = 0; i < 10; i++)
                {
                    int r = Random.Range(0, _roadPartPrefabs.Length);
                    GameObject obj;

                    obj = Instantiate(_roadPartPrefabs[r], transform);


                    RoadPart p = obj.GetComponent<RoadPart>();
                    obj.transform.position = _lastPart.EndPoint.position;
                    _lastPart.NextPart = p;
                    _lastPart = p;
                }
            }

            if (_lastObstacle.transform.position.z < 200)
            {
                _lastObstacle = null;

                int r = Random.Range(0, _objectPackPrefabs.Length);

                GameObject obj1 = Instantiate(_objectPackPrefabs[r], new Vector3(0, 0, 400), Quaternion.identity, transform);
                _lastObstacle = obj1.GetComponent<ObstaclePack>();
            }
        }
    }
}
