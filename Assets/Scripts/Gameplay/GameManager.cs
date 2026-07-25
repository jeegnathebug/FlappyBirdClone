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
        [SerializeField] private GameObject gameOverScreen;
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private Bird bird;
        [SerializeField] private PipeSpawner pipeSpawner;

        private void OnEnable()
        {
            MainMenu.StartButtonPressed += StartGame;
            GameOverMenu.RestartButtonPressed += RestartGame;
            GameOverMenu.ReturnToMenuButtonPressed += ReloadGame;
        }

        private void OnDisable()
        {
            MainMenu.StartButtonPressed -= StartGame;
            GameOverMenu.RestartButtonPressed -= RestartGame;
            GameOverMenu.ReturnToMenuButtonPressed -= ReloadGame;
        }

        private void Start()
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(false);
        }

        private void StartGame()
        {
            Time.timeScale = 1;
            gameOverScreen.SetActive(false);
        }

        public void GameOver()
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
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
