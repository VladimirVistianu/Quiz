using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniQuiz.Core.Entities
{
    public class Result
    {
        [Key]
        public Guid Id { get; set; }

        public int TotalPoints { get; set; }

        public string ResultJson { get; set; }

        public Quiz Quiz { get; set; }

        public Candidate Candidate { get; set; }
    }
}
