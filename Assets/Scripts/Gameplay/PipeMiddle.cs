using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Within the Pipe prefab. Used as a Trigger for scoring points. Each pipe has a separate PipeMiddle script.
    /// </summary>
    public class PipeMiddle : MonoBehaviour
    {
        private ScoreManager _scoreManager;

        private void Start()
        {
            _scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _scoreManager.AddScore();
        }
    }
}
