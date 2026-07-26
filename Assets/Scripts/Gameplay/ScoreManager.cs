using Core;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class ScoreManager : GameStateSubscriber
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        private int _score = 0;

        #region Unity Lifecycle

        private void Awake()
        {
            scoreText.text = _score.ToString();
        }

        #endregion

        /// <summary>
        /// Used in the PipeMiddle script to manage score
        /// </summary>
        public void AddScore(int score = 1)
        {
            _score += score;
            scoreText.text = _score.ToString();
        }

        protected override void Reset()
        {
            _score = 0;
            scoreText.text = _score.ToString();
        }
    }
}
