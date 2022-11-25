using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using StefaniniQuiz.Core.Entities;
using StefaniniQuiz.Core.Interfaces;
using StefaniniQuiz.Infrastructure.DTO.Quiz;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace StefaniniQuiz.Services.Services.Quizzes
{
    public class QuizServices : IQuizServices
    {
        private readonly IGenericRepository<Quiz> _quizRepository;
        private readonly IGenericRepository<Question> _questionRepository;
        private readonly IGenericRepository<Answer> _answerRepository;

        public QuizServices(IGenericRepository<Quiz> quizRepository, IGenericRepository<Question> questionRepository, IGenericRepository<Answer> answerRepository)
        {
            _quizRepository = quizRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
        }


        public async Task<Quiz> CreateQuiz(CreateQuizDTO data)
        {
            var quiz = new Quiz()
            {
                //Id = data.Id ?? Guid.NewGuid(),
                Title = data.Title,
                TechnologyName = data.TechnologyName,
                DateAdded = DateTime.Now,

                Questions = data.Questions.Select(x => new Question
                {
                    //Id = Guid.NewGuid(),
                    Title = x.Title,
                    Answers = x.Answers.Select(y => new Answer
                    {
                        IsCorrect = y.IsCorrect,
                        Point = y.Point,
                        AnswerText = y.AnswerText


                    }).ToList()
                }).ToList()
            };

            await _quizRepository.AddAsync(quiz);
            return quiz;
        }

        public async Task EditQuiz(Quiz editedQuiz) 
        {
     
            var existingQuiz = await GetQuiz(editedQuiz.Id);

            if (existingQuiz is null)
            {
                throw new Exception("Quiz not found.");
            }


            existingQuiz =  await _quizRepository.SetValues(existingQuiz, editedQuiz);

            //Delete
            foreach (var existingQuestion in existingQuiz.Questions.ToList())
            {
                if (!editedQuiz.Questions.Any(c => c.Id == existingQuestion.Id))
                {
                    foreach (var existingAnswer in existingQuestion.Answers)
                    {
                        await _answerRepository.DeleteAsync(existingAnswer);
                    }

                    await _questionRepository.DeleteAsync(existingQuestion);
                }
                else
                {
                    foreach (var existingAnswer in existingQuestion.Answers)
                    {
                        var editedQuestion = editedQuiz.Questions.Where(q => q.Id == existingQuestion.Id).FirstOrDefault();
                        if (editedQuestion is null) continue;

                        if (!editedQuestion.Answers.Any(c => c.Id == existingAnswer.Id))
                        {
                            await _answerRepository.DeleteAsync(existingAnswer);
                        }
                    }
                }
            }


            //Update and insert childrens

            foreach (var questionEdited in editedQuiz.Questions)
            {
                var existingQuestion = existingQuiz.Questions
                    .Where(q => q.Id == questionEdited.Id)
                    .FirstOrDefault();


                if (existingQuestion is null)
                {
                    existingQuestion = new Question
                    {
                        Id = questionEdited.Id,
                        Answers = questionEdited.Answers,
                        QuizID = questionEdited.QuizID,
                        Title = questionEdited.Title

                    };

                    existingQuiz.Questions.Add(existingQuestion);
                }
                else
                {
                    existingQuestion = await _questionRepository.SetValues(existingQuestion, questionEdited);
                }

                foreach (var answerEdited in questionEdited.Answers)
                {
                    var existingAnswer = existingQuestion.Answers
                        .Where(a=>a.Id == answerEdited.Id)
                        .FirstOrDefault();

                    if (existingAnswer != null)
                    {
                        existingAnswer = await _answerRepository.SetValues(existingAnswer, answerEdited);
                        await _answerRepository.Update(existingAnswer);
                    }
                    else
                    {
                        var newAnswer = new Answer
                        {
                            //Id = answerEdited.Id,
                            AnswerText = answerEdited.AnswerText,
                            IsCorrect = answerEdited.IsCorrect,
                            Point = answerEdited.Point,
                            QuestionId = answerEdited.QuestionId,
                        };
                        existingQuestion.Answers.Add(newAnswer);
                    }

                }
                await _questionRepository.Update(existingQuestion);

                //var existingQuestion = await _questionRepository.GetByIdAsync(questionEdited.Id);
                    //existingQuiz.Questions
                    //.Where(q => q.Id == questionEdited.Id && q.Id != Guid.Empty)
                    //.SingleOrDefault();

                
            }
            await _quizRepository.Update(existingQuiz);
           
            
            #region
            //var answerToEdit = new List<object>();
            //var answerToDelete = new List<object>();

            //var questionToEdit = new List<object>();
            //var questionToDelete = new List<object>();


            //foreach (var question in editQuizDTO.Questions)
            //{
            //    foreach (var answer in question.Answers)
            //    {
            //        answerToEdit.Add(answer);
            //    }

            //    questionToEdit.Add(question);
            //}

            //if (answerToEdit.Any())
            //{
            //    await _quizRepository.AddAsync(quiz, answerToEdit);
            //}

            //quiz.Title = editQuizDTO.Title;
            //quiz.TechnologyName = editQuizDTO.TechnologyName;
            //quiz.
            #endregion


            
        }

        public async Task<Quiz> GetQuiz(Guid id)
        {

            var quiz = await  _quizRepository.GetByIdAsync(id, include: source => source.Include(q => q.Questions).ThenInclude(q => q.Answers)); 
            
            return  quiz;
        }

        public async Task<ICollection<Quiz>> GetQuizzes()
        {
            var quiz =  await _quizRepository.GetAllAsync(include: source => source.Include(q => q.Questions).ThenInclude(a => a.Answers));
            return quiz;
        }



        //protected void UpdateQuizCol(
        //    List<> source,
        //    List<T> destinations,
        //    Action<T, T> cloneItem,
        //    Action<T> onDelete = null)
        //{
        //    //sources = sources.EmptyIfNull();


        //}

    }
}
