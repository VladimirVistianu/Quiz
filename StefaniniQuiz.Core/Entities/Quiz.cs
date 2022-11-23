using StefaniniQuiz.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace StefaniniQuiz.Core.Entities
{
    public class Quiz : IEntity
    {

        [Key]
        public Guid Id { get; set; }

        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(50)]
        public string TechnologyName { get; set; } //Dropdown box as an enum  -- get enum from Db table 

        public virtual ICollection<Question> Questions { get; set; } 
        public ICollection<Result> Results { get; set; } 

        public DateTime DateAdded { get; set; }

    }
}
