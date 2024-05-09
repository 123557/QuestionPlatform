namespace Yi.Abp.Application.Contracts.Dtos.Question
{
    /// <summary>
    /// Question输入创建对象
    /// </summary>
    public class QuestionCreateInput
    {
        public string? project { get; set; }
        public string? status { get; set; }
        public string? category { get; set; }
        public string? impact { get; set; }
        public string? priority { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? solve_user { get; set; }
        public string? Create_name { get; set; }


    }
}
