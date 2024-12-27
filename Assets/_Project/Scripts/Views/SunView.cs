using DNS.Controllers;
using DNS.Interfaces;
using UnityEngine;

namespace DNS.Views
{
    public class SunView : MonoBehaviour, IView
    {
        [SerializeField] private Light _sun;

        public IController Controller { get; set; }

        public void Init(IController controller)
        {
            Controller = (SunController)controller;
        }

        public void UpdateSun(float currentHours)
        {
            if(currentHours is < 0.0f or > 23.0f) return;
            
            var sunAngle = Mathf.Lerp(((SunController)Controller)._sunriseAngle,
                ((SunController)Controller)._sunsetAngle, currentHours / 24f);
            _sun.transform.rotation = Quaternion.Euler(sunAngle, -30f, 0f);

            _sun.intensity = currentHours switch
            {
                // Daytime
                >= 6 and < 18 => Mathf.Lerp(0, 1, Mathf.InverseLerp(6, 12, currentHours)), // Sunrise
                // Nighttime
                >= 18 or < 6 => Mathf.Lerp(1, 0,
                    Mathf.InverseLerp(18, 24, currentHours >= 18 ? currentHours : currentHours + 24)) // Sunset
            };
        }
    }
}