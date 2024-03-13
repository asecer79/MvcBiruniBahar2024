using System.ComponentModel.DataAnnotations;

namespace W03.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name cannot be blank!")]
        public string? Name { get; set; }

        [EmailAddress(ErrorMessage = "Bad Email format!")]
        public string? Email { get; set; }

        [Range(17,30,ErrorMessage = "Age must be between 17 and 30")]
        public int? Age { get; set; }

    }
}
