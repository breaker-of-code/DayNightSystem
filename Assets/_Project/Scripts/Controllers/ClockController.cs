using DNS.Interfaces;
using DNS.Models;
using DNS.Views;
using UnityEngine;

namespace DNS.Controllers
{
    public class ClockController : MonoBehaviour, IController
    {
        public enum ClockType
        {
            Analogue,
            Digital
        }

        [Header("Clock Type")] public ClockType _clockType;

        [Header("Timescale Value = 1 Hour")] [Range(1, 60)]
        public float _timeScale = 60f;
        
        [Header("Start Time (0-23 Hours)")] [Range(0, 23)]
        public int _startTime = 0;

        [Header("Clock Prefabs")] [SerializeField]
        private GameObject _analogueClockPrefab;

        [SerializeField] private GameObject _digitalClockPrefab;
        [SerializeField] private Transform _spawnParent;

        public IClock CurrentClock { get; private set; }

        [field: SerializeField, Space] public ClockView View { get; set; }

        private void Awake()
        {
            ApplyClockType();
        }

        private void Start()
        {
            View.Init(this);
        }

        private void ApplyClockType()
        {
            if (_analogueClockPrefab is null || _digitalClockPrefab is null || _spawnParent is null)
                return;

            switch (_clockType)
            {
                case ClockType.Analogue:
                {
                    CurrentClock = Instantiate(_analogueClockPrefab, _spawnParent).GetComponent<AnalogueClock>();

                    break;
                }
                case ClockType.Digital:
                {
                    CurrentClock = Instantiate(_digitalClockPrefab, _spawnParent).GetComponent<DigitalClock>();

                    break;
                }
            }

            CurrentClock?.SetTimeScale(_timeScale);
            CurrentClock?.SetCurrentTime(_startTime);
        }
    }
}