namespace StefaniniQuiz.Infrastructure.DTO.GetDTO
{
    public class GetQuizDTO
    {

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string TechnologyName { get; set; }

        public IEnumerable<GetQuestionDTO> Questions { get; set; }

        public DateTime DateAdded { get; set; }

    }
}
