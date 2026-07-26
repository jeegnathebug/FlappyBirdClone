using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay
{
    public class Bird : MonoBehaviour, IPausable
    {
        [SerializeField] private float flapStrength;
        [SerializeField] private Rigidbody2D rigidBody2D;
        [SerializeField] private GameManager gameManager;
        private InputAction _jumpAction;
        private Vector3 _startPosition;
        private bool _isRunning;

        #region Unity Lifecycle
        private void Start()
        {
            _jumpAction = InputSystem.actions.FindAction("Jump");
            _startPosition =  transform.position;
            rigidBody2D.linearVelocity = Vector2.zero;
            rigidBody2D.gravityScale = 0;
        }

        private void Update()
        {
            if (!_isRunning)
            {
                return;
            }

            if (_jumpAction.WasPressedThisFrame())
            {
                rigidBody2D.linearVelocity = Vector2.up * flapStrength;
            }
        }

        private void OnCollisionEnter2D()
        {
            gameManager.GameOver();
        }
        #endregion

        public void Resume()
        {
            _isRunning = true;
            rigidBody2D.gravityScale = 5;
        }

        public void Pause()
        {
            _isRunning = false;
            rigidBody2D.gravityScale = 0;
            rigidBody2D.linearVelocity = Vector2.zero;
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
