using System.ComponentModel.DataAnnotations;

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

        public DateTime DateAdded { get; set; }

        //public ICollection<Question> QuestionsList(List<Question> questions)
        //{
        //      Answer answer1 = new Answer() { Id = Guid.NewGuid(), AnswerText = "Blue", Point = 1, ValidAnswer = true };
        //      Answer answer2 = new Answer() { Id = Guid.NewGuid(), AnswerText = "Red", Point = 0, ValidAnswer = false };
        //      Answer answer3 = new Answer() { Id = Guid.NewGuid(), AnswerText = "Green", Point = 0, ValidAnswer = false };
        //      Answer answer4 = new Answer() { Id = Guid.NewGuid(), AnswerText = "Yellow", Point = 0, ValidAnswer = false };

        //      Question question1 = new Question() { Id = Guid.NewGuid(), Title = "What is the first color in the list Blue, Red, Green, Yellow", Answers = new List<Answer>() { answer1, answer2, answer3, answer4 } };


        //      var questionList = new List<Question>() { question1 };
        //      questions = questionList;
        //      return questions;


        //        //question1.Title = "Aloha",
        //      //question1.Answer = Answer blue = new Answer(){AnswerText = "blue", ValidAnswer = true};
        //      //questionAnswer answer1 = new Answer(){AnswerText= "amogus", ValidAnswer = false, Point = 2},
        //      //question1.Answers


        //    //Answer answer1 = new Answer() { Point = 1, ValidAnswer = false } ;
        //    //Answer answer2 = new Answer() { Point = 2 };
        //    //Answer answer3 = new Answer() { Point = 3 };

        //    //Answer = new List<Answer>() { answer1, answer2, answer3 }





            

        //    // Answer answer1 = new Answer() { Point = 1 , ValidAnswer = false} ;
        //    //Answer answer2 = new Answer() { Point = 2, ValidAnswer = false };
        //    //Answer answer3 = new Answer() { Point = 3 };
             
            
        //    //Question question1 = new Question() { Title = "What is the first color in list- Blue, Green, Red", Answer = new List<Answer>(){ answer1, answer2, answer3 },   };
        //    //Question question2 = new Question() { Title = "What is the first color in list- Red, Green, Blue", Answers = List<Answer>(answer1, answer2, ans) };
        //    //Question question3 = new Question() { Title = "What is the first color in list- Blue, Red, Gree" };



        //    //var questionList = new List<Question>() { question1, question2, question3 };
        //    //questions = questionList;
        //    //return questions;
        //}
  
    }
}
