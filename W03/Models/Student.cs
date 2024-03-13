using System.ComponentModel.DataAnnotations;

namespace W03.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name cannot be blank!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email cannot be blank!")]
        [EmailAddress(ErrorMessage = "Bad Email format!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Age cannot be blank!")]
        [Range(17,30,ErrorMessage = "Age must be between 17 and 30")]
        public int? Age { get; set; }

    }
}
