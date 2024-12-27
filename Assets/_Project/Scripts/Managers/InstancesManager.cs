using DNS.Controllers;
using UnityEngine;

namespace DNS.Managers
{
    public class InstancesManager : MonoBehaviour
    {
        public static InstancesManager SInstance;
        
        [SerializeField] private GameObject _controllersObj;
        
        [Space]
        public ClockController _clockController;
        public SunController _sunController;
        public SkyboxController _skyboxController;

        private void Awake()
        {
            SInstance ??= this;
            
            _controllersObj.SetActive(true);
        }

        private void OnDestroy()
        {
            SInstance = null;
        }
    }
}