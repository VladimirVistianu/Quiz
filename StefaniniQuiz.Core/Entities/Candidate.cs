using System.ComponentModel.DataAnnotations;

namespace StefaniniQuiz.Core.Entities
{
    public class Candidate
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }
    }
}
