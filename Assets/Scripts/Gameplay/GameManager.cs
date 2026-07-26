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

        private void Start()
        {
            gameOverMenu.Hide();
            bird.Pause();
            pipeSpawner.Pause();
        }
        #endregion

        private void StartGame()
        {
            gameOverMenu.Hide();
            bird.Resume();
            pipeSpawner.Resume();
        }

        public void GameOver()
        {
            gameOverMenu.Show();
            bird.Pause();
            pipeSpawner.Pause();
        }

        /// <summary>
        /// Called by GameScene > Canvas > Game Over Screen > RestartButton
        /// </summary>
        private void RestartGame()
        {
            scoreManager.ResetScore();
            bird.ResetBird();
            pipeSpawner.ResetPipes();

            StartGame();
        }

        /// <summary>
        /// Called by GameScene > Canvas > Game Over Screen > ReturnToMenuButton
        /// </summary>
        private void ReloadGame()
        {
            SceneLoader.Load(GameScene.GameScene);
        }
    }
}
