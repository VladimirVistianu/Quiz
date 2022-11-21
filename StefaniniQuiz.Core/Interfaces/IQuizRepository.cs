using StefaniniQuiz.Core.Entities;

namespace StefaniniQuiz.Core.Interfaces
{
    public interface IQuizRepository
    {
        Task CreateQuiz(Quiz quiz);
        Task<Quiz> GetQuiz(Guid id);
        Task<ICollection<Quiz>> GetQuizzes();
    }
}
