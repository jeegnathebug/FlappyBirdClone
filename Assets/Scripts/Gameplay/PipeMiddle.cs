using System;
using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Within the Pipe prefab. Used as a Trigger for scoring points. Each pipe has a separate PipeMiddle script.
    /// </summary>
    public class PipeMiddle : MonoBehaviour
    {
        public event Action<int> OnPointScored;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            OnPointScored?.Invoke(1);
        }
    }
}
