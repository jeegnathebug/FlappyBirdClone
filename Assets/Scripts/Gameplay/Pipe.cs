using Core;
using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Within the Pipe prefab. Used to move the pipe object along.
    /// </summary>
    public class Pipe : MonoBehaviour, IPausable, IStoppable, IResetable
    {
        [SerializeField] private float moveSpeed = 5;
        private const float DeadZone = -30;
        private bool _isRunning = false;

        #region Unity Lifecycle

        private void OnEnable()
        {
            GameManager.StateChanged += OnStateChanged;
        }

        private void OnDisable()
        {
            GameManager.StateChanged -= OnStateChanged;
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

        private void OnStateChanged(GameState state)
        {
            switch (state)
            {
                case GameState.Started:
                    Resume();
                    break;
                case GameState.Paused:
                    Pause();
                    break;
                case GameState.Stopped:
                    Stop();
                    break;
                case GameState.Restarted:
                    Reset();
                    break;
            }
        }

        public void Resume()
        {
            _isRunning = true;
        }

        public void Pause()
        {
            _isRunning = false;
        }

        public void Stop()
        {
            _isRunning = false;
        }

        public void Reset()
        {
            Destroy(gameObject);
        }
    }
}
