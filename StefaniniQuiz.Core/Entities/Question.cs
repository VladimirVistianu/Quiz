using System.ComponentModel.DataAnnotations;

namespace StefaniniQuiz.Core.Entities
{
    public class Question
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        public int TotalPoints => Answers.Any() ? Answers.Select(x => x.Point).Sum() : 0;

        public ICollection<Answer> Answers { get; set; }
        public Guid QuizID { get; set; }

        public Quiz Quiz { get; set; } 
        
    }
}
