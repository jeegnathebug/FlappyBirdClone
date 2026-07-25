using System;
using UnityEngine;
using Utility;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public static event Action StartButtonPressed;

        /// <summary>
        /// Called by the Menu's Start button.
        /// </summary>
        public void OnStartButtonPressed()
        {
            SceneLoader.UnloadAsync(GameScene.MainMenuScene);
            StartButtonPressed?.Invoke();
        }

        /// <summary>
        /// Called by the Menu's Quit button.
        /// </summary>
        public void OnQuitButtonPressed()
        {
            Application.Quit();
        }
    }
}
