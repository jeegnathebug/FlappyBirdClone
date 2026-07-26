using Core;
using UnityEngine;

namespace Gameplay
{
    public class PipeSpawner : GameStateSubscriber
    {
        [SerializeField] private GameObject pipe;
        [SerializeField] private float spawnRate = 2.5f;
        [SerializeField] private float heightOffset = 5;
        private float _timer;
        private bool _isRunning = false;

        #region Unity Lifecycle

        private void Start()
        {
            _timer = spawnRate; // Start by spawning a pipe immediately
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
                SpawnPipe();
                _timer = 0;
            }
        }

        #endregion

        private void SpawnPipe()
        {
            var highestPoint = transform.position.y + heightOffset;
            var lowestPoint = transform.position.y - heightOffset;

            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0),
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
