﻿namespace StefaniniQuiz.Infrastructure.DTO.GetDTO
{
    public class GetQuestionDTO
    {

        public Guid Id { get; set; }
        public string Title { get; set; }

        public int TotalPoints { get; set; }

        public IEnumerable<GetAnswerDTO> Answers { get; set; }

    }
}
