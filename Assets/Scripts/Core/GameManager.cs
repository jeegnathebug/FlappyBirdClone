using System;
using Gameplay;
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
        [SerializeField] private Bird bird;

        public static event Action<GameState> StateChanged;
        public static GameState State { get; private set; } = GameState.Stopped;

        #region Unity Lifecycle

        private void OnEnable()
        {
            MainMenu.StartButtonPressed += StartGame;
            gameOverMenu.RestartButtonPressed += RestartGame;
            gameOverMenu.ReturnToMenuButtonPressed += ReloadGame;
            bird.BirdCollision += EndGame;
        }

        private void OnDisable()
        {
            MainMenu.StartButtonPressed -= StartGame;
            gameOverMenu.RestartButtonPressed -= RestartGame;
            gameOverMenu.ReturnToMenuButtonPressed -= ReloadGame;
            bird.BirdCollision -= EndGame;
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

        private void StartGame()
        {
            gameOverMenu.Hide();
            SetState(GameState.Started);
        }

        private void EndGame()
        {
            gameOverMenu.Show();
            SetState(GameState.Stopped);
        }

        private void RestartGame()
        {
            gameOverMenu.Hide();
            SetState(GameState.Restarted);
            SetState(GameState.Started);
        }

        private void ReloadGame()
        {
            SceneLoader.Load(GameScene.GameScene);
        }
    }
}
