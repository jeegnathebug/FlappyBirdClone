using Core;
using System;
using UnityEngine;
using Utility;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public static event Action StartButtonPressed;
        [SerializeField] private GameObject creditPanel;
        [SerializeField] private GameObject menuPanel;

        /// <summary>
        /// Called by the Menu's Start button.
        /// </summary>
        public void OnStartButtonPressed()
        {
            SceneLoader.UnloadAsync(GameScene.MainMenuScene);
            StartButtonPressed?.Invoke();
        }

        public void OnCreditsButtonPressed()
        {
            creditPanel.SetActive(true);
            menuPanel.SetActive(false);
        }

        public void OnCreditsReturnButtonPressed()
        {
            creditPanel.SetActive(false);
            menuPanel.SetActive(true);
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
