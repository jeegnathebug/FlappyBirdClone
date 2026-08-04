using System;
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
        [SerializeField] private Gradient worldTintGradient;
        [SerializeField] private float cycleDuration = 120f;

        public static event Action<Color> TintChanged;

        private float _time;

        private void Update()
        {
            _time += Time.unscaledDeltaTime;

            var t = _time % cycleDuration / cycleDuration;

            mainCamera.backgroundColor = skyGradient.Evaluate(t);
            TintChanged?.Invoke(worldTintGradient.Evaluate(t));
        }
    }
}
