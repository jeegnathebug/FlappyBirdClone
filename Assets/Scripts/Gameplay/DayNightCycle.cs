using UnityEngine;

namespace Gameplay
{
    public class DayNightCycle : MonoBehaviour
    {
        public Camera mainCamera;

        public Gradient skyGradient;

        public float cycleDuration = 120f;

        private float _time;

        void Update()
        {
            _time += Time.unscaledDeltaTime;

            float t = _time % cycleDuration / cycleDuration;

            mainCamera.backgroundColor = skyGradient.Evaluate(t);
        }
    }
}
