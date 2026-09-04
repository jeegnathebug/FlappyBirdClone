using Core;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class ScoreManager : GameStateSubscriber
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI highscoreText;
        private int _score = 0;
        private int _highscore = 0;

        #region Unity Lifecycle

        private void Awake()
        {
            scoreText.text = _score.ToString();

            _highscore = PlayerPrefs.GetInt(nameof(PlayerPrefValues.HighScore), 0);
            highscoreText.text = _highscore.ToString();
        }

        #endregion

        /// <summary>
        /// Used in the ObstacleSpawner script to wire up events between a PipeMiddle instance and the ScoreManager
        /// </summary>
        public void AddScore(int score = 1)
        {
            _score += score;
            if (_score > _highscore)
            {
                _highscore = _score;
                highscoreText.text = _highscore.ToString();
                PlayerPrefs.SetInt(nameof(PlayerPrefValues.HighScore), _highscore);
            }
            scoreText.text = _score.ToString();
        }

        protected override void Reset()
        {
            _score = 0;
            scoreText.text = _score.ToString();
        }
    }
}
