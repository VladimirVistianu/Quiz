using StefaniniQuiz.Infrastructure.DTO.Question;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniQuiz.Infrastructure.DTO.Quiz
{
    public class EditQuizDTO
    {

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string TechnologyName { get; set; }

        public IEnumerable<EditQuestionDTO> Questions { get; set; } = Enumerable.Empty<EditQuestionDTO>();

        public DateTime DateAdded { get; set; }
    }
}
