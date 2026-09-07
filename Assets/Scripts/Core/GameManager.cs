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
        public static GameState State { get; private set; } = GameState.Menu;

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
            SetState(GameState.Reset);
            SetState(GameState.Playing);
            gameOverMenu.Hide();
        }

        public void ResumeGame()
        {
            SetState(GameState.Playing);
            pauseMenu.Hide();
        }

        public void PauseGame()
        {
            SetState(GameState.Stopped);
            SetState(GameState.Paused);
            pauseMenu.Show();
        }

        /// <summary>
        /// Used in the Bird when it collides and dies
        /// </summary>
        public void EndGame()
        {
            SetState(GameState.Stopped);
            gameOverMenu.Show();
        }

        private void ReloadGame()
        {;
            SetState(GameState.Menu);
            SceneLoader.Load(GameScene.GameScene);
        }
    }
}
