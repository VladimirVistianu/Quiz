﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniQuiz.Core.Entities
{
    public class Question
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        public int TotalPoints { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public Quiz Quiz { get; set; }

    }
}
