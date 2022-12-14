using StefaniniQuiz.Core.Interfaces;
using StefaniniQuiz.Infrastructure.Repositories;
using StefaniniQuiz.Services.Services;
using StefaniniQuiz.Services.Services.Quizzes;

namespace StefaniniQuiz.API.Extensions
{
    public static class Helpers
    {
        public static void AddScoped(this IServiceCollection services)
        {
            services.AddScoped<IQuizServices, QuizServices>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


        }
    }
}
