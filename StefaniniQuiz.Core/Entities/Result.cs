using StefaniniQuiz.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace StefaniniQuiz.Core.Entities
{
    public class Result : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public int TotalPoints { get; set; }

        public string ResultJson { get; set; }

        public Quiz Quiz { get; set; }

        public Candidate Candidate { get; set; }
    }
}
