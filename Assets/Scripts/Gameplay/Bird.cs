using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay
{
    public class Bird : MonoBehaviour
    {
        public Rigidbody2D rigidBody2D;
        public float flapStrength;
        private GameManager _gameManager;
        private InputAction _jumpAction;
        private Vector3 _startPosition;

        private void Start()
        {
            _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
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
        /// <param name="collision"></param>
        private void OnCollisionEnter2D(Collision2D collision)
        {
            _gameManager.GameOver();
        }

        public void ResetBird()
        {
            transform.position = _startPosition;
            rigidBody2D.linearVelocity = Vector2.zero;
        }
    }
}
