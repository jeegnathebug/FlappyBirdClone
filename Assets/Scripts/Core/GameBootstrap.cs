using UnityEngine;
using UnityEngine.SceneManagement;
using Utility;

namespace Core
{
    public class GameBootstrap : MonoBehaviour
    {
        /// <summary>
        /// Loads main menu on top of the actual game so we can smoothly transition into the game by removing the main
        /// menu when starting the game
        /// </summary>
        private void Start()
        {
            SceneLoader.Load(GameScene.MainMenuScene, LoadSceneMode.Additive);
            Time.timeScale = 0;
        }
    }
}
