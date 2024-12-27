using DNS.Interfaces;
using DNS.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace DNS.Models
{
    public class DigitalClock : MonoBehaviour, IClock
    {
        public TMP_Text _clockText;
        public bool _is24HourFormat = true;
        public bool _showSeconds = true;

        private float _timeScale;
        private float _currentTime;

        public UnityEvent<float> OnTimeUpdate { get; set; } = new();

        public void BindTimeUpdateEvent(UnityAction<float> onTimeUpdate)
        {
            OnTimeUpdate.AddListener(onTimeUpdate);
        }
        
        public void UnbindTimeUpdateEvent(UnityAction<float> onTimeUpdate)
        {
            OnTimeUpdate.RemoveListener(onTimeUpdate);
        }

        public void SetTimeScale(float timeScale)
        {
            _timeScale = InstancesManager.SInstance._clockController._timeScale;
        }

        private void UpdateDisplay()
        {
            var hours = _currentTime / 3600f;
            var minutes = (_currentTime % 3600f) / 60f;
            var seconds = _currentTime % 60f;

            if (!_is24HourFormat)
            {
                var period = hours >= 12 ? "PM" : "AM";
                hours %= 12;
                hours = hours == 0 ? 12 : hours;
                _clockText.text = _showSeconds
                    ? $"{hours:00}:{minutes:00}:{seconds:00} {period}"
                    : $"{hours:00}:{minutes:00} {period}";
            }
            else
            {
                _clockText.text = _showSeconds ? $"{hours:00}:{minutes:00}:{seconds:00}" : $"{hours:00}:{minutes:00}";
            }
            
            OnTimeUpdate?.Invoke(hours);
        }

        public (int hour, int minute) GetCurrentTime()
        {
            var totalSeconds = Mathf.FloorToInt(_currentTime);
            var hours = (totalSeconds / 3600) % 24;
            var minutes = (totalSeconds % 3600) / 60;

            return (hours, minutes);
        }

        public void SetCurrentTime(int startTime)
        {
            _currentTime = startTime * 3600f;
            UpdateDisplay();
        }
        
        public void UpdateTime(float deltaTime)
        {
            _currentTime += deltaTime * (60 / _timeScale);
            UpdateDisplay();
        }

        private void Update()
        {
            UpdateTime(Time.deltaTime);
        }
    }
}