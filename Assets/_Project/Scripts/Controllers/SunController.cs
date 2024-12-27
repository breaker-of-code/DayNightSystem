using DNS.Interfaces;
using DNS.Managers;
using DNS.Views;
using UnityEngine;

namespace DNS.Controllers
{
    public class SunController : MonoBehaviour, IController
    {
        [Header("Angle At 6:00 AM")] public float _sunriseAngle = 0f; // Angle at 6:00 AM
        [Header("Angle At 6:00 PM")] public float _sunsetAngle = 180f; // Angle at 6:00 PM

        [field: SerializeField, Space] public SunView View { get; set; }

        private void Start()
        {
            View.Init(this);
        }

        private void OnEnable()
        {
            InstancesManager.SInstance._clockController.CurrentClock.BindTimeUpdateEvent(View.UpdateSun);
        }

        private void OnDisable()
        {
            InstancesManager.SInstance._clockController.CurrentClock.UnbindTimeUpdateEvent(View.UpdateSun);
        }
    }
}