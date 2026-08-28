using UnityEngine;
using UnityEngine.InputSystem;

namespace Core
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;

        private InputAction _pauseAction;
        private InputAction _jumpAction;

        private void Awake()
        {
            _pauseAction = InputSystem.actions.FindAction(nameof(Control.Pause));
            _jumpAction = InputSystem.actions.FindAction(nameof(Control.Jump));
        }

        private void Update()
        {
            if (_pauseAction.WasPressedThisFrame())
            {
                HandlePause();
            }

            if (_jumpAction.WasPressedThisFrame())
            {
                HandleJump();
            }
        }

        private void HandlePause()
        {
            switch (GameManager.State)
            {
                case GameState.Paused:
                    gameManager.ResumeGame();
                    break;
                case GameState.Started:
                    gameManager.PauseGame();
                    break;
            }
        }

        private void HandleJump()
        {
            switch (GameManager.State)
            {
                case GameState.Stopped:
                    gameManager.RestartGame();
                    break;
            }
        }
    }
}
