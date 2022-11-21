using Microsoft.AspNetCore.Mvc;
using StefaniniQuiz.Core.Entities;
using StefaniniQuiz.Infrastructure.DTO;
using StefaniniQuiz.Infrastructure.DTO.GetDTO;
using StefaniniQuiz.Services.Services.Interfaces;

namespace StefaniniQuiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly IQuizServices _quizServices;
        private readonly IQuestionServices _questionServices;
        private readonly IAnswerServices _answerServices;

        public QuizzesController(IQuizServices quizServices, IQuestionServices questionServices, IAnswerServices answerServices)
        {
            _quizServices = quizServices;
            _questionServices = questionServices;
            _answerServices = answerServices;
        }

        [HttpGet]
        public async Task<ActionResult<GetQuizDTO>> GetQuizzes()
        {
            
            var quizzes = (await _quizServices.GetQuizzes())
                .Select(quiz => new GetQuizDTO
                {
                    Id = quiz.Id,
                    Title = quiz.Title,
                    TechnologyName = quiz.TechnologyName,
                    DateAdded = quiz.DateAdded,
                    Questions = quiz.Questions.Select(x => new GetQuestionDTO
                    {
                        Id = x.Id,
                        Title = x.Title,
                        TotalPoints = x.TotalPoints,
                        Answers = x.Answers.Select(y => new GetAnswerDTO
                        {
                            Id = y.Id,
                            AnswerText = y.AnswerText,
                            IsCorrect = y.IsCorrect,
                            Point = y.Point
                        })
                    })
                });
             
            return Ok(quizzes);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<GetQuizDTO>> GetQuiz(Guid id)
        {
            Quiz quiz = await _quizServices.GetQuiz(id);
            var getQuizDTO = new GetQuizDTO()
            {
                Id = quiz.Id,
                Title = quiz.Title,
                TechnologyName = quiz.TechnologyName,
                DateAdded = quiz.DateAdded,
                Questions = quiz.Questions.Select(x => new GetQuestionDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    TotalPoints = x.TotalPoints,
                    Answers = x.Answers.Select(y => new GetAnswerDTO
                    {
                        Id = y.Id,
                        AnswerText = y.AnswerText,
                        IsCorrect = y.IsCorrect,
                        Point = y.Point
                    })
                })
            };
            return Ok(getQuizDTO);
        }

        [HttpPost]
        public async Task<ActionResult> AddQuiz(CreateQuizDTO data)
        {
            var createdQuiz = await _quizServices.CreateQuiz(data);

            var getQuizDTO = new GetQuizDTO()
            {
                Id = createdQuiz.Id,
                Title = createdQuiz.Title,
                TechnologyName = createdQuiz.TechnologyName,
                DateAdded = createdQuiz.DateAdded,
                Questions = createdQuiz.Questions.Select(x => new GetQuestionDTO
                {
                    Id = x.Id,
                    Title = x.Title,
                    TotalPoints = x.TotalPoints,
                    Answers = x.Answers.Select(y => new GetAnswerDTO
                    {
                        Id = y.Id,
                        AnswerText = y.AnswerText,
                        IsCorrect = y.IsCorrect,
                        Point = y.Point
                    })
                })
            };

            return CreatedAtAction(nameof(GetQuiz), new { id = createdQuiz.Id }, getQuizDTO);
        }
    }
}
