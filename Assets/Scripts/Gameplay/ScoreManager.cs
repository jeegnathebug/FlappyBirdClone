using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        private int _score;

        /// <summary>
        /// Used in the PipeMiddle script to manage score
        /// </summary>
        public void AddScore(int score = 1)
        {
            _score += score;
            scoreText.text = _score.ToString();
        }

        /// <summary>
        /// Called by GameManager when restarting the game
        /// </summary>
        public void ResetScore()
        {
            _score = 0;
            scoreText.text = _score.ToString();
        }
    }
}
