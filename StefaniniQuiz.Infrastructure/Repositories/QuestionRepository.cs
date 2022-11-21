using StefaniniQuiz.Core.Entities;
using StefaniniQuiz.Core.Interfaces;
using StefaniniQuiz.Infrastructure.Data;

namespace StefaniniQuiz.Infrastructure.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly QuizDbContext _context;


        public QuestionRepository(QuizDbContext context)
        {
            _context = context;
        }

        public async Task CreateQuestion(Question question)
        {

            await _context.Question.AddAsync(question);
            await _context.SaveChangesAsync();

        }
    }
}
