using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniQuiz.Core.Entities
{
    public class Quiz
    {

        [Key]
        public Guid Id { get; set; }

        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(50)]
        public string TechnologyName { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<Result> Results { get; set; }

    }
}
