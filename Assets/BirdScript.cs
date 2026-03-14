using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    public float flapStrength;
    private InputAction _jumpAction;
    private LogicScript _logicScript;

    void Start()
    {
        _jumpAction = InputSystem.actions.FindAction("Jump");
        _logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (_logicScript.isGameOver())
        {
            return;
        }

        if (_jumpAction.IsPressed())
        {
            rigidBody2D.linearVelocity = Vector2.up * flapStrength;
        }
    }

    /// <summary>
    /// When birb collides with any Collider
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _logicScript.gameOver();
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
