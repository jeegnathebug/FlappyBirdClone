using Core;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utility;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public static event Action StartButtonPressed;
        [SerializeField] private GameObject creditPanel;
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private Button startButton;
        [SerializeField] private Button creditsReturnButton;

        public void OnEnable()
        {
            EventSystem.current.SetSelectedGameObject(startButton.gameObject);
        }

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
            EventSystem.current.SetSelectedGameObject(creditsReturnButton.gameObject);
        }

        public void OnCreditsReturnButtonPressed()
        {
            creditPanel.SetActive(false);
            menuPanel.SetActive(true);
            EventSystem.current.SetSelectedGameObject(startButton.gameObject);
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
