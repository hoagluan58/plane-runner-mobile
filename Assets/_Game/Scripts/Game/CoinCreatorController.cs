using UnityEngine;

namespace PlaneRunner
{
    public class CoinCreatorController : MonoBehaviour
    {
        [SerializeField] private GameObject _coinPrefab;

        [Header("Spawn Settings")]
        [SerializeField] private float _minSpawnDelay = 1f;
        [SerializeField] private float _maxSpawnDelay = 3f;

        [SerializeField] private Vector2 _randomYRange = new Vector2(10f, 28f);
        [SerializeField] private Vector2 _randomXRange = new Vector2(-15f, 15f);
        [SerializeField] private float _spawnZ = 400f;

        private float _nextSpawnTime = 0f;

        private void Update()
        {
            if (Time.time >= _nextSpawnTime)
            {
                SpawnCoin();
                ScheduleNextSpawn();
            }
        }

        private void SpawnCoin()
        {
            var x = Random.Range(_randomXRange.x, _randomXRange.y);
            var y = Random.Range(_randomYRange.x, _randomYRange.y);
            Vector3 spawnPos = new Vector3(x, y, _spawnZ);

            Instantiate(_coinPrefab, spawnPos, Quaternion.identity, transform);
        }

        private void ScheduleNextSpawn()
        {
            _nextSpawnTime = Time.time + Random.Range(_minSpawnDelay, _maxSpawnDelay);
        }
    }
}
