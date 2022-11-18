using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniQuiz.Core.Entities
{
    public class Answer
    {
        [Key]
        public Guid Id { get; set; }

        public int Point { get; set; }

        public bool ValidAnswer { get; set; }

        public Question Question { get; set; }

    }
}
