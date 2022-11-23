using Microsoft.EntityFrameworkCore;
using StefaniniQuiz.Core.Entities;
using StefaniniQuiz.Core.Interfaces;
using StefaniniQuiz.Infrastructure.DTO.Quiz;

namespace StefaniniQuiz.Services.Services.Quizzes
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

            await _quizRepository.AddAsync(quiz);
            return quiz;
        }

        public async Task<Quiz> GetQuiz(Guid id)
        {

            var quiz = await  _quizRepository.GetByIdAsync(id, include: source => source.Include(q => q.Questions).ThenInclude(q => q.Answers)); 
            
            return  quiz;
        }

        public async Task<ICollection<Quiz>> GetQuizzes()
        {
            var quiz =  await _quizRepository.GetAllAsync(include: source => source.Include(q => q.Questions).ThenInclude(a => a.Answers));
            return quiz;
        }




    }
}
