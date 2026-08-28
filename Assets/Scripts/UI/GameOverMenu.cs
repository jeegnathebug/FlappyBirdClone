using System;

namespace UI
{
    public class GameOverMenu : HideableMenu
    {
        public event Action RestartButtonPressed;
        public event Action ReturnToMenuButtonPressed;

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
