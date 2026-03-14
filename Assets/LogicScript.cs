using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool isGameOver()
    {
        return gameOverFlag;
    }
}
