using System.ComponentModel.DataAnnotations;

namespace StefaniniQuiz.Infrastructure.DTO.Answer
{
    public class CreateAnswerDTO
    {

        [MaxLength(255)]
        public string AnswerText { get; set; }
        public int Point { get; set; }

        public bool IsCorrect { get; set; }

    }
}
