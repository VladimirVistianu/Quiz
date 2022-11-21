using Microsoft.EntityFrameworkCore;
using StefaniniQuiz.Core.Entities;
using StefaniniQuiz.Core.Interfaces;
using StefaniniQuiz.Infrastructure.Data;

namespace StefaniniQuiz.Infrastructure.Repositories
{
    public class QuizRepository : IQuizRepository
    {
        private readonly QuizDbContext _context;


        public QuizRepository(QuizDbContext context)
        {
            _context = context; 
        }

        public async Task CreateQuiz(Quiz quiz)
        {
            
            await _context.Quizzes.AddAsync(quiz);
            await _context.SaveChangesAsync();

        }

        public async Task<Quiz> GetQuiz(Guid id)
        {
            return await _context.Quizzes
                .Include(q=>q.Questions)
                .ThenInclude(q=>q.Answers)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<ICollection<Quiz>> GetQuizzes()
        {
            return await _context.Quizzes
                .Include(q => q.Questions)
                .ThenInclude(q => q.Answers)
                .ToListAsync();
            
        }
    }   
}
