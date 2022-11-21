using StefaniniQuiz.Core.Entities;
using StefaniniQuiz.Core.Interfaces;
using StefaniniQuiz.Infrastructure.DTO;
using StefaniniQuiz.Infrastructure.DTO.GetDTO;
using StefaniniQuiz.Services.Services.Interfaces;

namespace StefaniniQuiz.Services.Services
{
    public class QuizServices : IQuizServices
    {
        private readonly IQuizRepository _quizRepository;
       

        public QuizServices(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }

     
        public async Task<Quiz> CreateQuiz(CreateQuizDTO data)
        {
            var quiz = new Quiz()
            {
                //Id = data.Id ?? Guid.NewGuid(),
                Title = data.Title,
                TechnologyName = data.TechnologyName,
                DateAdded = DateTime.Now,
                
                Questions = data.Questions.Select(x => new Question
                {
                    //Id = Guid.NewGuid(),
                    Title = x.Title,
                    Answers = x.Answers.Select(y => new Answer
                    {
                        IsCorrect = y.IsCorrect,
                        Point = y.Point,
                        AnswerText = y.AnswerText
                        

                    }).ToList()
                }).ToList()
            };

            await _quizRepository.CreateQuiz(quiz);
            return quiz;
        }

        public async Task<Quiz> GetQuiz(Guid id)
        {
            var quiz = await _quizRepository.GetQuiz(id);
            return quiz;
        }

        public async Task<ICollection<Quiz>> GetQuizzes()
        {
          return await _quizRepository.GetQuizzes();
        }
    }
}
