using System;
using UI;
using UnityEngine;
using Utility;

namespace Gameplay
{
    /// <summary>
    /// Game state actions. Used in Bird and MainMenu
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static event Action GameStarted;
        public static event Action GameStopped;
        public static event Action GameRestarted;

        [SerializeField] private GameOverMenu gameOverMenu;
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private Bird bird;
        [SerializeField] private PipeSpawner pipeSpawner;

        #region Unity Lifecycle
        private void OnEnable()
        {
            MainMenu.StartButtonPressed += StartGame;
            gameOverMenu.RestartButtonPressed += RestartGame;
            gameOverMenu.ReturnToMenuButtonPressed += ReloadGame;
        }

        private void OnDisable()
        {
            MainMenu.StartButtonPressed -= StartGame;
            gameOverMenu.RestartButtonPressed -= RestartGame;
            gameOverMenu.ReturnToMenuButtonPressed -= ReloadGame;
        }
        #endregion

        private void StartGame()
        {
            gameOverMenu.Hide();
            GameStarted?.Invoke();
        }

        public void EndGame()
        {
            gameOverMenu.Show();
            GameStopped?.Invoke();
        }

        private void RestartGame()
        {
            GameRestarted?.Invoke();
            StartGame();
        }

        private void ReloadGame()
        {
            SceneLoader.Load(GameScene.GameScene);
        }
    }
}
