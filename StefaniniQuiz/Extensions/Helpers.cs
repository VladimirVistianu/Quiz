using StefaniniQuiz.Core.Interfaces;
using StefaniniQuiz.Infrastructure.Repositories;
using StefaniniQuiz.Services.Services.Interfaces;
using StefaniniQuiz.Services.Services;

namespace StefaniniQuiz.API.Extensions
{
    public static class Helpers
    {
        public static void AddScoped(this IServiceCollection services)
        {
            services.AddScoped<IQuizRepository, QuizRepository>();
            services.AddScoped<IQuizServices, QuizServices>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuestionServices, QuestionServices>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IAnswerServices, AnswerServices>();
            
        }
    }
}
