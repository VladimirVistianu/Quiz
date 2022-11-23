using StefaniniQuiz.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace StefaniniQuiz.Core.Entities
{
    public class Answer : IEntity
    {
        [Key]
        public Guid Id { get; set; }


        [MaxLength(255)]
        public string AnswerText { get; set; }
        public int Point { get; set; }

        public bool IsCorrect { get; set; }
        
        public Guid QuestionId { get; set; }

        public  Question Question { get; set; }

    }
}
