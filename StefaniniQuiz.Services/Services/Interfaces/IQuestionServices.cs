using StefaniniQuiz.Core.Entities;

namespace StefaniniQuiz.Services.Services.Interfaces
{
    public interface IQuestionServices
    {
        Task CreateQuestions(Question question);
    }
}
