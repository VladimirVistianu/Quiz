using StefaniniQuiz.Core.Entities;
using StefaniniQuiz.Infrastructure.DTO;

namespace StefaniniQuiz.Services.Services.Interfaces
{
    public interface IQuizServices
    {
        Task<Quiz> CreateQuiz(CreateQuizDTO quiz);
        Task<Quiz> GetQuiz(Guid id);
        Task<ICollection<Quiz>> GetQuizzes();
    }
}
