using System.Timers;

namespace MyPortfoliio.Services
{
    public enum NotifyLevel
    {
        Info,
        Success,
        Warning,
        Error
    }
    public class NotifyService : IDisposable
    {
        public event Action<string, NotifyLevel>? OnShow;
        public event Action? OnHide;
        private System.Timers.Timer? Countdown;

        public void ShowNotify(string message, NotifyLevel level)
        {
            OnShow?.Invoke(message, level);
            StartCountdown();
        }

        private void StartCountdown()
        {
            SetCountdown();

            if (Countdown!.Enabled)
            {
                Countdown.Stop();
                Countdown.Start();
            }
            else
            {
                Countdown!.Start();
            }
        }

        private void SetCountdown()
        {
            if (Countdown != null) return;

            Countdown = new System.Timers.Timer(7000);
            Countdown.Elapsed += HideNotify;
            Countdown.AutoReset = false;
        }

        private void HideNotify(object? source, ElapsedEventArgs args)
            => OnHide?.Invoke();

        public void Dispose()
            => Countdown?.Dispose();
    }
}
