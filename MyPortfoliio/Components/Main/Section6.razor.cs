using MyPortfoliio.Interface;
using MyPortfoliio.Services;

namespace MyPortfoliio.Components.Main
{
    public partial class Section6
    {
        protected async Task HandleValidSubmit()
        {
            onSubmitLoading = true;
            await Task.Run(Submitting);
            
        }
        private async void Submitting()
        {
            try
            {
                //onSubmitLoading = true;

                string _emailName = _mailInfo.EmailName;
                string _emailFrom = _mailInfo.EmailFrom;
                string _emailContent = _mailInfo.EmailContent;
                string _toEmail = "e.salazar.v.252@gmail.com";

                var rp = File.ReadAllText($"./Formatos/EmailFormat.html");
                rp = rp.Replace("$NombreUsuario$", _emailName)
                       .Replace("$ContenidoEmail$", _emailContent)
                       .Replace("$EmailUsuario$", _emailFrom);

            await MailService.SendEmailAsync(_toEmail,"Un usuario se está comunicando a travez del Portafolio", rp);

                //onSubmitLoading = false;

            NotifyService.ShowNotify("Your email was sent correctly", NotifyLevel.Success);
                onSubmitLoading = false;
                await InvokeAsync(StateHasChanged);


            }
            catch (Exception ex)
            {
                //string errorDetail = "Account/ForgotPassword.razor/ForgotPassword.razor.cs/Submitting => Exception message: " + ex.Message + "\n" + ", Stack Trace: " + ex.StackTrace;
                //_lg.ErrorLog(errorDetail, errorTitle);
                string exceptionerror = "Se produjo un error <br/>Error: " + ex.Message;
                NotifyService.ShowNotify(exceptionerror, NotifyLevel.Error);
                onSubmitLoading = false;
                await InvokeAsync(StateHasChanged);
            }
        }
    }
}
