using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameBootstrap : MonoBehaviour
    {
        private void Start()
        {
            SceneLoader.Load(GameScene.MainMenuScene, LoadSceneMode.Additive);
            Time.timeScale = 0;
        }
    }
}
