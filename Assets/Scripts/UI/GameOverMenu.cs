using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UI
{
    public class GameOverMenu : MonoBehaviour
    {
        public static event Action RestartButtonPressed;
        public static event Action ReturnToMenuButtonPressed;

        // Keyboard action
        private InputAction _jumpAction;
        private const float ButtonEnabledDelayTime = .5f;
        private float _waitTimer;

        private void Start()
        {
            _jumpAction = InputSystem.actions.FindAction("Jump");
        }

        private void Update()
        {
            // Wait a bit before allowing keyboard press to trigger button
            if (_waitTimer < ButtonEnabledDelayTime)
            {
                _waitTimer += Time.unscaledDeltaTime;
                return;
            }

            if (!_jumpAction.WasPressedThisFrame()) return;

            _waitTimer = 0;
            OnRestartButtonPressed();
        }

        /// <summary>
        /// Called by the Game Over Screen's Restart button.
        /// </summary>
        public void OnRestartButtonPressed()
        {
            RestartButtonPressed?.Invoke();
        }

        /// <summary>
        /// Called by the Game Over Screen's ReturnToMenu button.
        /// </summary>
        public void OnReturnToMenuButtonPressed()
        {
            ReturnToMenuButtonPressed?.Invoke();
        }
    }
}
