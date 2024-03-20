using System.ComponentModel.DataAnnotations;

namespace ObsWebUI.Models.Entities
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field cannot be empty!")]
        public string? Name { get; set; }

        public string? DeanName { get; set; }


    }
}
