using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ExceptionServices;

namespace Lab8.Models
{
    [Table("Lera")]
    public class Lera
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? FirstName{ get; set; }
        public string? LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Status { get; set; } = "active";
        public string Role { get; set; } = "user";

        public Lera(
            string first,
            string last,
            string email,
            string password)
        {
            FirstName = first; 
            LastName = last; 
            Email = email;
            Password = password;
        }

        public Lera(
            string email,
            string password) 
        {
            Email = email;
            Password = password;
        }

        public Lera() { }

    }
}
