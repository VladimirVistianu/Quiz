using Microsoft.EntityFrameworkCore;
using StefaniniQuiz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniQuiz.Infrastructure.Data
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
        {

        }

        public DbSet<Quiz> Quizzes { get; set; }

        public DbSet<Question> Question { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<Result> Results { get; set; }

        public DbSet<Candidate> Candidates { get; set; }



    }
}
