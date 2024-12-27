using DNS.Interfaces;
using DNS.Managers;
using UnityEngine;
using UnityEngine.Events;

namespace DNS.Models
{
    public class AnalogueClock : MonoBehaviour, IClock
    {
        public Transform _hourHand;
        public Transform _minuteHand;
        public Transform _secondHand;
        public bool _showSecondHand = true;

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

        private void UpdateHandRotations()
        {
            var hours = _currentTime / 3600f;
            var minutes = (_currentTime % 3600f) / 60f;
            var seconds = _currentTime % 60f;

            _hourHand.localRotation = Quaternion.Euler(0, 0, -hours * 30f);
            _minuteHand.localRotation = Quaternion.Euler(0, 0, -minutes * 6f);

            if (_showSecondHand && _secondHand != null)
            {
                _secondHand.localRotation = Quaternion.Euler(0, 0, -seconds * 6f);
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
            UpdateHandRotations();
        }
        
        public void UpdateTime(float deltaTime)
        {
            _currentTime += deltaTime * (60 / _timeScale);
            UpdateHandRotations();
        }

        private void Update()
        {
            UpdateTime(Time.deltaTime);
        }
    }
}