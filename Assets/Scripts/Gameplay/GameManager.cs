using Core;
using UnityEngine;

namespace Gameplay
{
    public class GameManager : MonoBehaviour
    {
        public GameObject gameOverScreen;
        public ScoreManager scoreManager;
        public Bird bird;
        public PipeSpawner pipeSpawner;

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
