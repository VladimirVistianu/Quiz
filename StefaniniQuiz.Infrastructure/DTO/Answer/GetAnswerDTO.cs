namespace StefaniniQuiz.Infrastructure.DTO.Answer
{
    public class GetAnswerDTO
    {
        public Guid Id { get; set; }
        public string AnswerText { get; set; }
        public int Point { get; set; }

        public bool IsCorrect { get; set; }
    }
}
