using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Within the Pipe prefab. Used to move the pipe object along.
    /// </summary>
    public class Pipe : MonoBehaviour, IPausable, IResetable
    {
        [SerializeField] private float moveSpeed = 5;
        private const float DeadZone = -30;
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
            _isRunning = true;
        }

        private void Update()
        {
            if (!_isRunning)
            {
                return;
            }

            transform.position += moveSpeed * Time.deltaTime * Vector3.left;

            // When the Pipe moves out of view, destroy it
            if (transform.position.x < DeadZone)
            {
                Destroy(gameObject);
            }
        }
        #endregion

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
            Destroy(gameObject);
        }
    }
}
