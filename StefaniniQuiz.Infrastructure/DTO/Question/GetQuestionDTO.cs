using StefaniniQuiz.Infrastructure.DTO.Answer;

namespace StefaniniQuiz.Infrastructure.DTO.Question
{
    public class GetQuestionDTO
    {

        public Guid Id { get; set; }
        public string Title { get; set; }

        public int TotalPoints { get; set; }

        public IEnumerable<GetAnswerDTO> Answers { get; set; }

    }
}
