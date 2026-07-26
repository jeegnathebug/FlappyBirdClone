using UnityEngine;

namespace Gameplay
{
    public class PipeSpawner : MonoBehaviour, IPausable
    {
        [SerializeField] private GameObject pipe;
        [SerializeField] private float spawnRate = 2.5f;
        [SerializeField] private float heightOffset = 5;
        private float _timer;
        private bool _isRunning;

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

        public void Resume()
        {
            _isRunning = true;

            foreach (Transform child in transform)
            {
                if (child.TryGetComponent<IPausable>(out var pausable))
                {
                    pausable.Resume();
                }
            }
        }

        public void Pause()
        {
            _isRunning = false;

            foreach (Transform child in transform)
            {
                if (child.TryGetComponent<IPausable>(out var pausable))
                {
                    pausable.Pause();
                }
            }
        }

        private void SpawnPipe()
        {
            var highestPoint = transform.position.y + heightOffset;
            var lowestPoint = transform.position.y - heightOffset;

            GameObject newPipe = Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation, transform);
            newPipe.GetComponent<PipeMove>().Resume();
        }

        /// <summary>
        /// Called by GameManager when restarting the game
        /// </summary>
        public void ResetPipes()
        {
            _timer = spawnRate;
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
