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

        public void StartGame()
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
        public void RestartGame()
        {
            scoreManager.ResetScore();
            bird.ResetBird();
            pipeSpawner.ResetPipes();

            StartGame();
        }

        /// <summary>
        /// Called by GameScene > Canvas > Game Over Screen > ReturnToMenuButton
        /// </summary>
        public void ReturnToMenu()
        {
            SceneLoader.Load(GameScene.GameScene);
        }
    }
}
