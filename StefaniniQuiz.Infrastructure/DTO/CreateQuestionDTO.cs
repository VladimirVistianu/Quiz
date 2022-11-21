using System.ComponentModel.DataAnnotations;

namespace StefaniniQuiz.Infrastructure.DTO
{
    public class CreateQuestionDTO
    {
      

        [StringLength(255)]
        public string Title { get; set; }

        public int TotalPoints => Answers.Any() ? Answers.Select(x => x.Point).Sum() : 0;

        public IEnumerable<CreateAnswerDTO> Answers { get; set; }
        
    }
}
