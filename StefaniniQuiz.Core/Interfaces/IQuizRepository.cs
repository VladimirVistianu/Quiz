using StefaniniQuiz.Core.Entities;

namespace StefaniniQuiz.Core.Interfaces
{
    public interface IQuizRepository : IGenericRepository<Quiz>
    {
        // Toate repozitoriile trebuie sa mosteneasca de la  Repository Generica <T>
    }
}
