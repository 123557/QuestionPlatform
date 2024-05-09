using Yi.Framework.Ddd;
using Yi.Framework.Ddd.Application.Contracts;

namespace Yi.Abp.Application.Contracts.Dtos.Question
{
    /// <summary>
    /// 查询参数
    /// </summary>
    public class QuestionGetListInput : PagedAllResultRequestDto
    {

        public Guid? CreatorId { get; set; }
        public string? project { get; set; }
        public string? status { get; set; }
        public string? category { get; set; }
        public string? impact { get; set; }
        public string? priority { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? Create_name { get; set; }
    }
}
