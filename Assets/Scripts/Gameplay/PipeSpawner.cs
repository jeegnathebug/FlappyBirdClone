using UnityEngine;

namespace Gameplay
{
    public class PipeSpawner : MonoBehaviour, IPausable, IResetable
    {
        [SerializeField] private GameObject pipe;
        [SerializeField] private float spawnRate = 2.5f;
        [SerializeField] private float heightOffset = 5;
        private float _timer;
        private bool _isRunning;

        #region Unity Lifecycle
        private void OnEnable()
        {
            GameManager.GameStarted += Resume;
            GameManager.GameStopped += Pause;
            GameManager.GameRestarted += Reset;
        }

        private void OnDisable()
        {
            GameManager.GameStarted -= Resume;
            GameManager.GameStopped -= Pause;
            GameManager.GameRestarted -= Reset;
        }

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

            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation, transform);
        }

        public void Resume()
        {
            _isRunning = true;
        }

        public void Pause()
        {
            _isRunning = false;
        }

        public void Reset()
        {
            _timer = spawnRate;
        }
    }
}
