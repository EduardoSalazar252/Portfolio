using System.ComponentModel.DataAnnotations;

namespace MyPortfoliio.Models
{
    public class MailViewModel
    {
        [Required(ErrorMessage ="*Required information")]
        public string EmailName{ get; set; }

        [Required(ErrorMessage = "*Required information")]
        [EmailAddress(ErrorMessage = "Invalid Email")]        
        public string EmailFrom { get; set; }

        [Required(ErrorMessage = "*Required information")]
        public string EmailContent { get; set; }
    }
}
