using StefaniniQuiz.Core.Entities;

namespace StefaniniQuiz.Services.Services.Interfaces
{
    public interface IAnswerServices
    {
        Task CreateAnswer(Answer answer);
    }
}
