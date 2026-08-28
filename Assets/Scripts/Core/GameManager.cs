using System;
using UI;
using UnityEngine;
using Utility;

namespace Core
{
    /// <summary>
    /// Game state actions
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameOverMenu gameOverMenu;
        [SerializeField] private PauseMenu pauseMenu;

        public static event Action<GameState> StateChanged;
        public static GameState State { get; private set; } = GameState.Stopped;

        #region Unity Lifecycle

        private void OnEnable()
        {
            MainMenu.StartButtonPressed += StartGame;
            pauseMenu.ResumeButtonPressed += ResumeGame;
            pauseMenu.ReturnToMenuButtonPressed += ReloadGame;
            gameOverMenu.RestartButtonPressed += StartGame;
            gameOverMenu.ReturnToMenuButtonPressed += ReloadGame;
        }

        private void OnDisable()
        {
            MainMenu.StartButtonPressed -= StartGame;
            pauseMenu.ResumeButtonPressed -= ResumeGame;
            pauseMenu.ReturnToMenuButtonPressed -= ReloadGame;
            gameOverMenu.RestartButtonPressed -= StartGame;
            gameOverMenu.ReturnToMenuButtonPressed -= ReloadGame;
        }

        #endregion

        private static void SetState(GameState state)
        {
            if (State == state)
            {
                return;
            }

            State = state;
            StateChanged?.Invoke(state);
        }

        public void StartGame()
        {
            gameOverMenu.Hide();
            SetState(GameState.Reset);
            SetState(GameState.Playing);
        }

        public void ResumeGame()
        {
            pauseMenu.Hide();
            SetState(GameState.Playing);
        }

        public void PauseGame()
        {
            pauseMenu.Show();
            SetState(GameState.Stopped);
            SetState(GameState.Paused);
        }

        /// <summary>
        /// Used in the Bird when it collides and dies
        /// </summary>
        public void EndGame()
        {
            gameOverMenu.Show();
            SetState(GameState.Stopped);
        }

        private void ReloadGame()
        {
            SceneLoader.Load(GameScene.GameScene);
        }
    }
}
