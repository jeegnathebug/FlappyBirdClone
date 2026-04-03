using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Within the Pipe prefab. Used to move the pipe object along.
    /// </summary>
    public class PipeMove : MonoBehaviour
    {
        public float moveSpeed = 5;
        private const float DeadZone = -30;

        private void Update()
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.left;

            // If Pipe moves out of view, destroy it
            if (transform.position.x < DeadZone)
            {
                Destroy(gameObject);
            }
        }
    }
}
