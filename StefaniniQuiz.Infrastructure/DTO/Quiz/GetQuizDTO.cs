using StefaniniQuiz.Infrastructure.DTO.Question;

namespace StefaniniQuiz.Infrastructure.DTO.Quiz
{
    public class GetQuizDTO
    {

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string TechnologyName { get; set; }

        public IEnumerable<GetQuestionDTO> Questions { get; set; } = Enumerable.Empty<GetQuestionDTO>();

        public DateTime DateAdded { get; set; }

    }
}
