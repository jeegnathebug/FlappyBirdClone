using Core;
using UnityEngine;

namespace Utility
{
    public class Scroller : GameStateSubscriber
    {
        [SerializeField] private float speed;
        private bool _isRunning = false;

        private void Start()
        {
            _isRunning = GameManager.State == GameState.Started;
        }

        private void Update()
        {
            if (!_isRunning)
            {
                return;
            }

            transform.position += speed * Time.deltaTime * Vector3.left;
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
    }
}
