using Core;
using Gameplay;
using UnityEngine;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        private GameManager _gameManager;

        public void StartGame()
        {
            _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
            SceneLoader.UnloadAsync(GameScene.MainMenuScene);
            _gameManager.StartGame();
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
