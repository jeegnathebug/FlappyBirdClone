using System;
using Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay
{
    public class Bird : MonoBehaviour, IPausable, IStoppable, IResetable
    {
        [SerializeField] private float flapStrength;

        public event Action Collision;

        private InputAction _jumpAction;
        private Rigidbody2D _rigidBody2D;
        private readonly Vector3 _startPosition = Vector3.zero;
        private bool _isRunning = false;

        #region Unity Lifecycle

        private void Awake()
        {
            _jumpAction = InputSystem.actions.FindAction("Jump");
            _rigidBody2D = GetComponent<Rigidbody2D>();
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
                _rigidBody2D.linearVelocity = Vector2.up * flapStrength;
            }
        }

        private void OnCollisionEnter2D()
        {
            Collision?.Invoke();
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
            _rigidBody2D.gravityScale = 5;
        }

        public void Pause()
        {
            _isRunning = false;
            _rigidBody2D.gravityScale = 0;
        }

        public void Stop()
        {
            _isRunning = false;
            _rigidBody2D.gravityScale = 0;
            _rigidBody2D.linearVelocity = Vector2.zero;
        }

        public void Reset()
        {
            _isRunning = false;
            transform.position = _startPosition;
            _rigidBody2D.gravityScale = 0;
            _rigidBody2D.linearVelocity = Vector2.zero;
        }
    }
}
