using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class DayNightTint : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private bool _isRunning = false;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            _isRunning = true;
        }

        private void OnDisable()
        {
            _isRunning = false;
        }

        private void Update()
        {
            if (!_isRunning)
            {
                return;
            }

            _spriteRenderer.color = DayNightCycle.CurrentTint;
        }
    }
}
