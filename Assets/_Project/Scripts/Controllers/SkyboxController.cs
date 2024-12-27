using DNS.Interfaces;
using DNS.Managers;
using DNS.Views;
using UnityEngine;

namespace DNS.Controllers
{
    public class SkyboxController : MonoBehaviour, IController
    {
        public Material _dayNightSkybox;
        
        [field: SerializeField, Space] public SkyboxView View { get; set; }
        
        private void Start()
        {
            View.Init(this);
        }

        private void OnEnable()
        {
            InstancesManager.SInstance._clockController.CurrentClock.BindTimeUpdateEvent(View.UpdateSkybox);
        }

        private void OnDisable()
        {
            InstancesManager.SInstance._clockController.CurrentClock.UnbindTimeUpdateEvent(View.UpdateSkybox);
        }
    }
}