using UnityEngine;

public class CloudSpawnScript : MonoBehaviour
{
    public GameObject cloud;
    private readonly float _spawnRate = 30f;
    private readonly float _heightOffset = 1.5f;
    private float _timer = 0;
    private LogicScript _logicScript;

    void Start()
    {
        _logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        spawnCloud();
        spawnCloud(transform.position.x);
    }

    void Update()
    {
        if (_logicScript.isGameOver())
        {
            return;
        }

        if (_timer < _spawnRate)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            spawnCloud();
            _timer = 0;
        }
    }

    private void spawnCloud(float xPosition = 35)
    {
        float highestPoint = transform.position.y + _heightOffset;
        float lowestPoint = transform.position.y - _heightOffset;

        Instantiate(cloud, new Vector3(xPosition, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
