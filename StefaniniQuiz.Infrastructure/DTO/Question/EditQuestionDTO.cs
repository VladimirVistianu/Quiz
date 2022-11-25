using StefaniniQuiz.Infrastructure.DTO.Answer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StefaniniQuiz.Infrastructure.DTO.Question
{
    public class EditQuestionDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public int TotalPoints { get; set; }

        public IEnumerable<EditAnswerDTO> Answers { get; set; }
    }
}
