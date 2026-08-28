using Core;

namespace Gameplay
{
    /// <summary>
    /// Within the Pipe prefab. Used to move the pipe object along.
    /// </summary>
    public class Pipe : GameStateSubscriber
    {
        private const float DeadZone = -30;
        private bool _isRunning = false;

        #region Unity Lifecycle

        private void Start()
        {
            _isRunning = GameManager.State == GameState.Playing;
        }

        private void Update()
        {
            if (!_isRunning)
            {
                return;
            }

            // When the Pipe moves out of view, destroy it
            if (transform.position.x < DeadZone)
            {
                Destroy(gameObject);
            }
        }

        #endregion

        protected override void Resume()
        {
            _isRunning = true;
        }

        protected override void Stop()
        {
            _isRunning = false;
        }

        protected override void Reset()
        {
            Destroy(gameObject);
        }
    }
}
