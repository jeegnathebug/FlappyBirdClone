using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Button gameOverButton;
    private InputAction _jumpAction;
    private LogicScript _logicScript;
    private readonly float _buttonEnabledDelayTime = .5f;
    private float _waitTimer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _jumpAction = InputSystem.actions.FindAction("Jump");
        _logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_logicScript.isGameOver())
        {
            return;
        }

        // Wait a bit before allowing keyboard press to trigger button
        if (_waitTimer < _buttonEnabledDelayTime)
        {
            _waitTimer += Time.deltaTime;
            return;
        }

        if (_jumpAction.IsPressed())
        {
            gameOverButton.onClick.Invoke();
        }
    }
}
