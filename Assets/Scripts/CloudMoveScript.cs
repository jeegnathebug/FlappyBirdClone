using UnityEngine;

public class CloudMoveScript : MonoBehaviour
{
    public float moveSpeed = 1;
    private float _deadZone = -40;
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
            Destroy(gameObject);
        }
    }
}
