using System.ComponentModel.DataAnnotations;

namespace ECommerceMVC.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage ="User Name could not be empty")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password could not be empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
