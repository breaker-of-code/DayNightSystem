using DNS.Controllers;
using DNS.Interfaces;
using UnityEngine;

namespace DNS.Views
{
    public class SkyboxView : MonoBehaviour, IView
    {
        public IController Controller { get; set; }

        public void Init(IController controller)
        {
            Controller = (SkyboxController)controller;

            RenderSettings.skybox = ((SkyboxController)Controller)._dayNightSkybox;
        }

        public void UpdateSkybox(float currentHours)
        {
            float blendFactor;

            if (currentHours is >= 6f and <= 18f) // Daytime
            {
                blendFactor = Mathf.InverseLerp(6f, 8f, currentHours);
            }
            else // Nighttime
            {
                blendFactor = currentHours > 18f
                    ? Mathf.InverseLerp(18f, 24f, currentHours)
                    : Mathf.InverseLerp(-6f, 0f, currentHours - 24f); // Wraps around midnight
            }

            RenderSettings.skybox.SetFloat("_Blend", blendFactor);
            DynamicGI.UpdateEnvironment();
        }
    }
}