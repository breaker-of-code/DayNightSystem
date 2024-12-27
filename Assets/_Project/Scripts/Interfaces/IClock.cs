using UnityEngine.Events;

namespace DNS.Interfaces
{
    public interface IClock
    {
        public UnityEvent<float> OnTimeUpdate { get; set; }
        void BindTimeUpdateEvent(UnityAction<float> onTimeUpdate);
        void UnbindTimeUpdateEvent(UnityAction<float> onTimeUpdate);
        void SetTimeScale(float timeScale);
        void UpdateTime(float deltaTime);
        (int hour, int minute) GetCurrentTime();
        void SetCurrentTime(int startTime);
    }
}