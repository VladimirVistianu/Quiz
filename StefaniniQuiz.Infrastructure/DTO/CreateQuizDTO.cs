namespace StefaniniQuiz.Infrastructure.DTO
{
    public class CreateQuizDTO
    {


        public Guid? Id { get; set; }

        public string Title { get; set; }    

        public string TechnologyName { get; set; }

        public IEnumerable<CreateQuestionDTO> Questions { get; set; }

        public DateTime DateAdded { get; set; }



    }
}
