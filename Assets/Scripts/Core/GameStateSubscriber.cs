using UnityEngine;

namespace Core
{
    public abstract class GameStateSubscriber : MonoBehaviour
    {
        protected virtual void OnEnable()
        {
            GameManager.StateChanged += OnStateChanged;
        }

        protected virtual void OnDisable()
        {
            GameManager.StateChanged -= OnStateChanged;
        }

        private void OnStateChanged(GameState state)
        {
            switch (state)
            {
                case GameState.Playing:
                    Resume();
                    break;

                case GameState.Stopped:
                    Stop();
                    break;

                case GameState.Reset:
                    Reset();
                    break;
            }
        }

        protected virtual void Resume() { }

        protected virtual void Stop() { }

        protected virtual void Reset() { }
    }
}
