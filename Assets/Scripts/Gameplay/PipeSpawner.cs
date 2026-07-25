using UnityEngine;

namespace Gameplay
{
    public class PipeSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject pipe;
        [SerializeField] private float spawnRate = 2.5f;
        [SerializeField] private float heightOffset = 5;
        private float _timer;

        private void Start()
        {
            _timer = spawnRate;
        }

        private void Update()
        {
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

        private void SpawnPipe()
        {
            var highestPoint = transform.position.y + heightOffset;
            var lowestPoint = transform.position.y - heightOffset;

            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation, transform);
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
