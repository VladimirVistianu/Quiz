using StefaniniQuiz.Core.Entities;
using StefaniniQuiz.Core.Interfaces;
using StefaniniQuiz.Services.Services.Interfaces;

namespace StefaniniQuiz.Services.Services
{
    public class AnswerServices : IAnswerServices
    {
       
        private readonly IAnswerRepository _answerRepository;


        public AnswerServices(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }


        public async Task CreateAnswer(Answer answer)
        {

            await _answerRepository.CreateAnswer(answer);
        }
    }
    
}
