using StefaniniQuiz.Core.Entities;
using StefaniniQuiz.Infrastructure.DTO.Quiz;

namespace StefaniniQuiz.Services.Services.Quizzes
{
    public interface IQuizServices
    {
        Task<Quiz> CreateQuiz(CreateQuizDTO quiz);
        Task<Quiz> GetQuiz(Guid id);
        //Task<Quiz> UpdateQuiz(CreateQuizDTO quiz);
        Task<ICollection<Quiz>> GetQuizzes();
    }
}
