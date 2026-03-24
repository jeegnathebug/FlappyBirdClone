using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Within the Pipe prefab. Used as a Trigger for scoring points.
    /// </summary>
    public class PipeMiddle : MonoBehaviour
    {
        private ScoreManager _scoreManager;
        private bool _scoreIncreased;

        private void Start()
        {
            _scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // Fail-safe to prevent scoring multiple times at one pipe
            if (!_scoreIncreased)
            {
                _scoreManager.AddScore();
            }
            _scoreIncreased = true;
        }
    }
}
