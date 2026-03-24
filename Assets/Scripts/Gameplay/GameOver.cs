using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Gameplay
{
    /// <summary>
    /// Used to add keyboard actions to the Game Over Screen
    /// </summary>
    public class GameOver : MonoBehaviour
    {
        public Button gameOverButton;
        private InputAction _jumpAction;
        private readonly float _buttonEnabledDelayTime = .5f;
        private float _waitTimer;

        private void Start()
        {
            _jumpAction = InputSystem.actions.FindAction("Jump");
        }

        private void Update()
        {
            // Wait a bit before allowing keyboard press to trigger button
            if (_waitTimer < _buttonEnabledDelayTime)
            {
                _waitTimer += Time.unscaledDeltaTime;
                return;
            }

            if (_jumpAction.WasPressedThisFrame())
            {
                _waitTimer = 0;
                gameOverButton.onClick.Invoke();
            }
        }
    }
}
