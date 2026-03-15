using Core;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneLoader.Load(GameScene.GameScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
