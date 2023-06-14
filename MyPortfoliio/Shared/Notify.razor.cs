using MyPortfoliio.Services;

namespace MyPortfoliio.Shared
{
    public partial class Notify
    {
        protected override void OnInitialized()
        {
            NotifyService.OnShow += ShowNotify;
            NotifyService.OnHide += HideNotify;
        }

        private async void ShowNotify(string message, NotifyLevel level)
        {
            BuildNotifySettings(level, message);
            _isVisible = true;
            await InvokeAsync(StateHasChanged);
        }

        private async void HideNotify()
        {
            _isVisible = false;
            await InvokeAsync(StateHasChanged);
        }

        private void BuildNotifySettings(NotifyLevel level, string message)
        {
            switch (level)
            {
                case NotifyLevel.Info:
                    _backgroundCssClass = $"bg-info";
                    _iconCssClass = "info";
                    _heading = "Info";
                    break;
                case NotifyLevel.Success:
                    _backgroundCssClass = $"bg-success";
                    _iconCssClass = "checkmark";
                    _heading = "Success";
                    break;
                case NotifyLevel.Warning:
                    _backgroundCssClass = $"bg-warning";
                    _iconCssClass = "warning";
                    _heading = "Warning";
                    break;
                case NotifyLevel.Error:
                    _backgroundCssClass = "bg-danger";
                    _iconCssClass = "blocked";
                    _heading = "Error";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null);
            }

            _message = message;
        }

        void IDisposable.Dispose()
        {
            NotifyService.OnShow -= ShowNotify;
            NotifyService.OnHide -= HideNotify;
        }
    }
}
