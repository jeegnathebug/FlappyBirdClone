using Gameplay;
using UnityEngine;
using Utility;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        private GameManager _gameManager;

        public void StartGame()
        {
            // Need to get it like this instead of assigning it in the Inspector because it's in a different scene
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
