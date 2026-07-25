using UnityEngine;

namespace Gameplay
{
    /// <summary>
    /// Controls the sky gradient in the Game and Main Menu screens
    /// </summary>
    public class DayNightCycle : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Gradient skyGradient;
        [SerializeField] private float cycleDuration = 120f;
        private float _time;

        private void Update()
        {
            _time += Time.unscaledDeltaTime;

            var t = _time % cycleDuration / cycleDuration;

            mainCamera.backgroundColor = skyGradient.Evaluate(t);
        }
    }
}
