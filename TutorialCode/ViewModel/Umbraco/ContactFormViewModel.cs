using System.ComponentModel.DataAnnotations;

namespace TutorialCode.ViewModel.Umbraco
{
    public class ContactFormViewModel
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required]
        public bool NaughtyOrNice { get; set; }

        [Required]
        [MaxLength(500)]
        public string SantasList { get; set; }
    }
}
