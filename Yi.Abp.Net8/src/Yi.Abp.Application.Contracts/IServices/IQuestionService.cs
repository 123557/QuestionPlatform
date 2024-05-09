using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Yi.Abp.Application.Contracts.Dtos.Question;
using Yi.Framework.Ddd.Application.Contracts;


namespace Yi.Abp.Application.Contracts.IServices
{
    /// <summary>
    /// Question服务抽象
    /// </summary>
    public interface IQuestionService : IYiCrudAppService<QuestionGetOutputDto, QuestionGetListOutputDto, Guid, QuestionGetListInput, QuestionCreateInput, QuestionUpdateInput>
    {

    }
}
