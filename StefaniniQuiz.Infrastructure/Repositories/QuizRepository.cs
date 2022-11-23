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



    }
}
