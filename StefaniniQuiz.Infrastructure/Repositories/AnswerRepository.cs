using StefaniniQuiz.Core.Entities;
using StefaniniQuiz.Core.Interfaces;
using StefaniniQuiz.Infrastructure.Data;

namespace StefaniniQuiz.Infrastructure.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly QuizDbContext _context;


        public AnswerRepository(QuizDbContext context)
        {
            _context = context;
        }

        public async Task CreateAnswer(Answer answer)
        {

            await _context.Answers.AddAsync(answer);
            await _context.SaveChangesAsync();

        }
    }
}
