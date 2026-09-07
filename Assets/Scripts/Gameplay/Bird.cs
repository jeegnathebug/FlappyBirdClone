using Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay
{
    public class Bird : GameStateSubscriber
    {
        [SerializeField] private float flapStrength;
        [SerializeField] private GameManager gameManager;
        [SerializeField] private AudioClip flapSound;

        private InputAction _jumpAction;
        private Rigidbody2D _rigidBody2D;
        private readonly Vector3 _startPosition = Vector3.zero;
        private bool _isRunning = false;

        #region Unity Lifecycle

        private void Awake()
        {
            _jumpAction = InputSystem.actions.FindAction(nameof(Control.Jump));
            _rigidBody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            Reset();
        }

        private void Update()
        {
            if (!_isRunning)
            {
                return;
            }

            if (_jumpAction.WasPressedThisFrame())
            {
                _rigidBody2D.linearVelocity = Vector2.up * flapStrength;
                AudioSource.PlayClipAtPoint(flapSound, _rigidBody2D.position);
            }
        }

        private void OnCollisionEnter2D()
        {
            gameManager.EndGame();
        }

        #endregion

        protected override void Resume()
        {
            _isRunning = true;
            _rigidBody2D.gravityScale = 5;
        }

        protected override void Stop()
        {
            _isRunning = false;
            _rigidBody2D.gravityScale = 0;
            _rigidBody2D.linearVelocity = Vector2.zero;
        }

        protected override void Reset()
        {
            _isRunning = false;
            transform.position = _startPosition;
            _rigidBody2D.gravityScale = 0;
            _rigidBody2D.linearVelocity = Vector2.zero;
        }
    }
}
