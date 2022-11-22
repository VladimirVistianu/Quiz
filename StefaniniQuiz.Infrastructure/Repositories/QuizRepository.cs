using Microsoft.EntityFrameworkCore;
using StefaniniQuiz.Core.Entities;
using StefaniniQuiz.Core.Interfaces;
using StefaniniQuiz.Infrastructure.Data;

namespace StefaniniQuiz.Infrastructure.Repositories
{
    public class QuizRepository : GenericRepository<Quiz>, IQuizRepository
    {

        private readonly QuizDbContext _context;

        public QuizRepository(QuizDbContext context) : base(context)
        {
            _context = context; 
        }

        public override async Task<Quiz> GetByIdAsync(Guid id)
        {
            return await _context.Quizzes
                .Include(q=>q.Questions)
                .ThenInclude(q=>q.Answers)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public override async Task<ICollection<Quiz>> GetAllAsync()
        {
            return await _context.Quizzes
                .Include(q => q.Questions)
                .ThenInclude(q => q.Answers)
                .ToListAsync();
            
        }
    }   
}
