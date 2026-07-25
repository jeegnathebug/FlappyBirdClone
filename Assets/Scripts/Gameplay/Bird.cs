using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay
{
    public class Bird : MonoBehaviour
    {
        [SerializeField] private float flapStrength;
        [SerializeField] private Rigidbody2D rigidBody2D;
        [SerializeField] private GameManager gameManager;
        private InputAction _jumpAction;
        private Vector3 _startPosition;

        private void Start()
        {
            _jumpAction = InputSystem.actions.FindAction("Jump");
            _startPosition =  transform.position;
        }

        private void Update()
        {
            if (_jumpAction.WasPressedThisFrame())
            {
                rigidBody2D.linearVelocity = Vector2.up * flapStrength;
            }
        }

        /// <summary>
        /// When bird collides with any Collider
        /// </summary>
        private void OnCollisionEnter2D()
        {
            gameManager.GameOver();
        }

        /// <summary>
        /// Called by GameManager when restarting the game
        /// </summary>
        public void ResetBird()
        {
            transform.position = _startPosition;
            rigidBody2D.linearVelocity = Vector2.zero;
        }
    }
}
