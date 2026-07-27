using UnityEngine;

namespace Utility
{
    public class Looper : MonoBehaviour
    {
        private Transform _other;
        private SpriteRenderer _spriteRenderer;
        private float _width;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _width = _spriteRenderer.bounds.size.x;

            foreach (Transform child in transform.parent)
            {
                if (child == transform) continue;
                _other = child;
                break;
            }
        }

        private void Update()
        {
            if (transform.position.x <= -_width)
            {
                transform.position = new Vector3(
                    _other.position.x + _width,
                    transform.position.y,
                    transform.position.z);
            }
        }
    }
}
