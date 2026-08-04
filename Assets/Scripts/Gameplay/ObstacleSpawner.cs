using Core;
using UnityEngine;

namespace Gameplay
{
    public class ObstacleSpawner : GameStateSubscriber
    {
        [SerializeField] private GameObject obstacle;
        [SerializeField] private float spawnRate;
        [SerializeField] private float topOffset;
        [SerializeField] private float bottomOffset;
        [SerializeField] private bool spawnImmediately;
        private float _timer;
        private bool _isRunning = false;

        #region Unity Lifecycle

        private void Start()
        {
            if (spawnImmediately)
            {
                _timer = spawnRate;
            }
        }

        private void Update()
        {
            if (!_isRunning)
            {
                return;
            }

            if (_timer < spawnRate)
            {
                _timer += Time.deltaTime;
            }
            else
            {
                SpawnObstacle();
                _timer = 0;
            }
        }

        #endregion

        private void SpawnObstacle()
        {
            var highestPoint = transform.position.y + topOffset;
            var lowestPoint = transform.position.y - bottomOffset;

            Instantiate(obstacle, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0),
                transform.rotation, transform);
        }

        protected override void Resume()
        {
            _isRunning = true;
        }

        protected override void Pause()
        {
            _isRunning = false;
        }

        protected override void Stop()
        {
            _isRunning = false;
        }

        protected override void Reset()
        {
            _isRunning = false;
            _timer = spawnRate;
        }
    }
}
