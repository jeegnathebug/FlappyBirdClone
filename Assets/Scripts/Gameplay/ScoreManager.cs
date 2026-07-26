using Core;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class ScoreManager : MonoBehaviour, IResetable
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        private int _score;

        #region Unity Lifecycle

        private void OnEnable()
        {
            GameManager.GameRestarted += Reset;
        }

        private void OnDisable()
        {
            GameManager.GameRestarted -= Reset;
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

        public void Reset()
        {
            _score = 0;
            scoreText.text = _score.ToString();
        }
    }
}
