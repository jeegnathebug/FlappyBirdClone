using Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay
{
    public class Bird : MonoBehaviour, IPausable, IStoppable, IResetable
    {
        [SerializeField] private float flapStrength;
        [SerializeField] private Rigidbody2D rigidBody2D;
        [SerializeField] private GameManager gameManager;
        private InputAction _jumpAction;
        private readonly Vector3 _startPosition = Vector3.zero;
        private bool _isRunning = false;

        #region Unity Lifecycle

        private void Awake()
        {
            _jumpAction = InputSystem.actions.FindAction("Jump");
        }

        private void OnEnable()
        {
            GameManager.StateChanged += OnStateChanged;
        }

        private void OnDisable()
        {
            GameManager.StateChanged -= OnStateChanged;
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
                rigidBody2D.linearVelocity = Vector2.up * flapStrength;
            }
        }

        private void OnCollisionEnter2D()
        {
            gameManager.EndGame();
        }

        #endregion

        private void OnStateChanged(GameState state)
        {
            switch (state)
            {
                case GameState.Started:
                    Resume();
                    break;
                case GameState.Paused:
                    Pause();
                    break;
                case GameState.Stopped:
                    Stop();
                    break;
                case GameState.Restarted:
                    Reset();
                    break;
            }
        }

        public void Resume()
        {
            _isRunning = true;
            rigidBody2D.gravityScale = 5;
        }

        public void Pause()
        {
            _isRunning = false;
            rigidBody2D.gravityScale = 0;
        }

        public void Stop()
        {
            _isRunning = false;
            rigidBody2D.gravityScale = 0;
            rigidBody2D.linearVelocity = Vector2.zero;
        }

        public void Reset()
        {
            _isRunning = false;
            transform.position = _startPosition;
            rigidBody2D.gravityScale = 0;
            rigidBody2D.linearVelocity = Vector2.zero;
        }
    }
}
