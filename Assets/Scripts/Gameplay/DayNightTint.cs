using UnityEngine;

namespace Gameplay
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class DayNightTint : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            DayNightCycle.TintChanged += OnTintChanged;
        }

        private void OnDisable()
        {
            DayNightCycle.TintChanged -= OnTintChanged;
        }

        private void OnTintChanged(Color tint)
        {
            _spriteRenderer.color = tint;
        }
    }
}
