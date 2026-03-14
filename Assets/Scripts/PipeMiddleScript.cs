using UnityEngine;

/// <summary>
/// Within the Pipe prefab. Used as a Trigger for scoring points.
/// </summary>
public class PipeMiddleScript : MonoBehaviour
{
    private LogicScript _logicScript;
    private bool _scoreIncreased = false;

    void Start()
    {
        _logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Fail-safe to prevent scoring multiple times at one pipe
        if (!_scoreIncreased)
        {
            _logicScript.addScore(1);
        }
        _scoreIncreased = true;
    }
}
