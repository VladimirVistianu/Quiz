using StefaniniQuiz.Core.Entities;

namespace StefaniniQuiz.Core.Interfaces
{
    public interface IQuestionRepository
    {
        Task CreateQuestion(Question question);
    }
}
