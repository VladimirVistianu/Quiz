using StefaniniQuiz.Core.Entities;

namespace StefaniniQuiz.Core.Interfaces
{
    public interface IAnswerRepository
    {
        Task CreateAnswer(Answer answer);
    }
}
