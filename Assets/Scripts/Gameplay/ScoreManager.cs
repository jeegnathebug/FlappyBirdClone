using Core;
using TMPro;
using UnityEngine;

namespace Gameplay
{
    public class ScoreManager : MonoBehaviour, IResetable
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        private int _score = 0;

        #region Unity Lifecycle

        private void Awake()
        {
            scoreText.text = _score.ToString();
        }

        private void OnEnable()
        {
            GameManager.StateChanged += OnStateChanged;
        }

        private void OnDisable()
        {
            GameManager.StateChanged -= OnStateChanged;
        }

        #endregion

        private void OnStateChanged(GameState state)
        {
            switch (state)
            {
                case GameState.Restarted:
                    Reset();
                    break;
            }
        }

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
