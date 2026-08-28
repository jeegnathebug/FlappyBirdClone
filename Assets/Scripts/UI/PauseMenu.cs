using System;

namespace UI
{
    public class PauseMenu : HideableMenu
    {
        public event Action ResumeButtonPressed;
        public event Action ReturnToMenuButtonPressed;

        /// <summary>
        /// Called by the Pause Menu's Resume button.
        /// </summary>
        public void OnResumeButtonPressed()
        {
            ResumeButtonPressed?.Invoke();
        }

        /// <summary>
        /// Called by the Pause Menu's Return to Menu button.
        /// </summary>
        public void OnQuitButtonPressed()
        {
            ReturnToMenuButtonPressed?.Invoke();
        }
    }
}
