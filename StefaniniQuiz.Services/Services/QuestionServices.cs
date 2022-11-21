using StefaniniQuiz.Core.Entities;
using StefaniniQuiz.Core.Interfaces;
using StefaniniQuiz.Services.Services.Interfaces;

namespace StefaniniQuiz.Services.Services
{
    public class QuestionServices : IQuestionServices
    {
        private readonly IQuestionRepository _questionRepository;


        public QuestionServices(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task CreateQuestions(Question question)
        {
           

            await _questionRepository.CreateQuestion(question);
            
        }
    }
}
