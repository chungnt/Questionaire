namespace QuestionnaireApi.Entities
{
    public class FormState
    {
        public int Id { get; set; }
        public Form? Form { get; set; }
        public Question? CurrentQuestion { get; set; }
        public User? User { get; set; }
        public FormStateType FormStateType { get; set; } = new FormStateType();
    }
}
