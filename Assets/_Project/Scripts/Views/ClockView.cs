using DNS.Controllers;
using DNS.Interfaces;
using UnityEngine;

namespace DNS.Views
{
    public class ClockView : MonoBehaviour, IView
    {
        public IController Controller { get; set; }

        public void Init(IController controller)
        {
            Controller = (ClockController)controller;
        }
    }
}