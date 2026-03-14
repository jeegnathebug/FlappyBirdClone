using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    private readonly float _deadZone = -30;
    private LogicScript _logicScript;

    void Start()
    {
        _logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (_logicScript.isGameOver())
        {
            return;
        }

        transform.position += moveSpeed * Time.deltaTime * Vector3.left;

        if (transform.position.x < _deadZone)
        {
            Debug.Log("Pipe destroyed");
            Destroy(gameObject);
        }
    }
}
