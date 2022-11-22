using Microsoft.AspNetCore.Mvc;
using StefaniniQuiz.Core.Entities;
using StefaniniQuiz.Infrastructure.DTO.Answer;
using StefaniniQuiz.Infrastructure.DTO.Question;
using StefaniniQuiz.Infrastructure.DTO.Quiz;
using StefaniniQuiz.Services.Services.Quizzes;

namespace StefaniniQuiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : ControllerBase
    {
        private readonly IQuizServices _quizServices;
      
        public QuizzesController(IQuizServices quizServices)
        {
            _quizServices = quizServices;
           
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

        //Paginare , o lista de 20 obiecte se transmite 
        // POst QuizDTO - Id la obiect ca return, status message OK , iD la obiect
        //Delete(guid id)


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

        //[HttpPut("{id}")]
        //public async Task<ActionResult<GetQuestionDTO>> UpdateQuiz(Guid id, CreateQuizDTO quizDTO)
        //{
        //    Quiz quiz = await _quizServices.GetQuiz(id);
        //    return;
        //}


       // la EDITARE LA QUIZ FOLOSIM HTTPPOST nu put , fiindca editam tot obiectul dar nu numa o ceva
       /*
        Quiz controller  
        */

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
