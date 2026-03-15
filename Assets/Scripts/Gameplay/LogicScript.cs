using Core;
using TMPro;
using UnityEngine;

public class LogicScript : MonoBehaviour
{

    public int playerScore = 0;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    private bool gameOverFlag = false;

    [ContextMenu("Increase Score")]
    public void addScore(int score = 1)
    {
        playerScore += score;
        scoreText.text = playerScore.ToString();
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        gameOverFlag = true;
    }

    /// <summary>
    /// Called by Canvas > Game Over Screen
    /// </summary>
    public void restartGame()
    {
        SceneLoader.Load(GameScene.GameScene);
    }

    /// <summary>
    /// Called by Canvas > Game Over Screen
    /// </summary>
    public void returnToMenu()
    {
        SceneLoader.Load(GameScene.MainMenuScene);
    }

    public bool isGameOver()
    {
        return gameOverFlag;
    }
}
