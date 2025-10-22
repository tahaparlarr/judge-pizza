using System.ComponentModel.DataAnnotations;

namespace JudgePizzaApp.Models.ViewModels
{
    public class ContactFormViewModel
    {
        [Required(ErrorMessage = "İsim gerekli")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyisim gerekli")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "E-posta gerekli")]

        [EmailAddress(ErrorMessage = "Geçerli bir e-posta giriniz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Mesajınızı yazınız")]
        public string Message { get; set; }
    }
}
