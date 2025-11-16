using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

namespace PlaneRunner
{
    public class WorldCreatorController : MonoBehaviour
    {
        public GameObject[] _roadPartPrefabs;
        public GameObject[] _objectPackPrefabs;
        public GameObject[] _itemPackPrefabs;

        [ReadOnly]
        public RoadPart _lastPart;
        [ReadOnly]
        public ObstaclePack _lastObstacle;
        [ReadOnly]
        public List<ObstaclePack> _obstacles;

        [ReadOnly]
        private int _obstacleCounter = 0;
        [ReadOnly]
        private int _itemCounter = 0;


        void Start()
        {
            _obstacles = new List<ObstaclePack>();

            RoadPart last = null;
            for (int i = 0; i < 10; i++)
            {
                GameObject obj = Instantiate(_roadPartPrefabs[0]);
                RoadPart p = obj.GetComponent<RoadPart>();

                if (i == 0)
                {
                    obj.transform.position = Vector3.zero;
                    //PlayerCar.m_Current.m_CurrentRoadPart = p;
                }
                else
                {
                    obj.transform.position = last.EndPoint.position;
                    //obj.transform.rotation = Quaternion.Euler(0, i * 3, 0);
                }

                if (last != null)
                {
                    last.NextPart = p;
                }
                last = p;
                _lastPart = last;
            }


            int r = Random.Range(0, _objectPackPrefabs.Length);
            GameObject obj1 = Instantiate(_objectPackPrefabs[r]);
            obj1.transform.position = new Vector3(0, 0, 500);
            _lastObstacle = obj1.GetComponent<ObstaclePack>();


        }

        // Update is called once per frame
        void Update()
        {
            if (_lastPart.transform.position.z < 200)
            {

                for (int i = 0; i < 10; i++)
                {
                    int r = Random.Range(0, _roadPartPrefabs.Length);
                    GameObject obj;

                    obj = Instantiate(_roadPartPrefabs[r]);


                    RoadPart p = obj.GetComponent<RoadPart>();
                    obj.transform.position = _lastPart.EndPoint.position;
                    //obj.transform.rotation = m_LastPart.transform.rotation;
                    _lastPart.NextPart = p;
                    _lastPart = p;
                }
            }

            if (_lastObstacle.transform.position.z < 200)
            {
                //Destroy(m_LastObstacle.gameObject,2);
                _lastObstacle = null;

                int r = Random.Range(0, _objectPackPrefabs.Length);

                GameObject obj1 = Instantiate(_objectPackPrefabs[r], new Vector3(0, 0, 400), Quaternion.identity);
                _lastObstacle = obj1.GetComponent<ObstaclePack>();
            }
        }
    }
}
