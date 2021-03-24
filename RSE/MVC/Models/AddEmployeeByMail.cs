using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public abstract class AddEmployeeByMail
    {
        [Required]
        [DisplayName("Email de l'employer")]
        [MaxLength(400)]
        [MinLength(5)]
        public string Email { get; set; }

        public AddEmployeeByMail()
        {

        }
        public AddEmployeeByMail(string email)
        {
            Email = email;
        }
    }
}