using SqlSugar;
using Volo.Abp.Application.Dtos;
using Yi.Abp.Application.Contracts.Dtos.Question;
using Yi.Abp.Application.Contracts.IServices;
using Yi.Abp.Domain.Entities;
using Yi.Framework.Ddd.Application;
using Yi.Framework.SqlSugarCore.Abstractions;

namespace Yi.Abp.Application.Services
{
    /// <summary>
    /// Question服务实现
    /// </summary>
    public class QuestionService : YiCrudAppService<QuestionEntity, QuestionGetOutputDto, QuestionGetListOutputDto, Guid, QuestionGetListInput, QuestionCreateInput, QuestionUpdateInput>,
       IQuestionService
    {
        private ISqlSugarRepository<QuestionEntity, Guid> _repository;
        public QuestionService(ISqlSugarRepository<QuestionEntity, Guid> repository) : base(repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 多查
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task<PagedResultDto<QuestionGetListOutputDto>> GetListAsync(QuestionGetListInput input)
        {
            RefAsync<int> total = 0;
            //.WhereIF(!input.CreatorId.Equals(Guid.Empty), x => x.CreatorId.Equals(input.CreatorId))
            var entities = await _repository._DbQueryable
                          .WhereIF(!string.IsNullOrEmpty(input.CreatorId.ToString()), x => x.CreatorId.Equals(input.CreatorId))
                          .WhereIF(!string.IsNullOrEmpty(input.project), x => x.project.Contains(input.project!))
                          .WhereIF(!string.IsNullOrEmpty(input.status), x => x.status.Contains(input.status!))
                          .WhereIF(!string.IsNullOrEmpty(input.category), x => x.category.Contains(input.category!))
                          .WhereIF(!string.IsNullOrEmpty(input.impact), x => x.impact.Contains(input.impact!))
                          .WhereIF(!string.IsNullOrEmpty(input.description), x => x.impact.Contains(input.description!))
                          .WhereIF(!string.IsNullOrEmpty(input.priority), x => x.priority.Contains(input.priority!))
                          .WhereIF(!string.IsNullOrEmpty(input.title), x => x.impact.Contains(input.title!))
                          .WhereIF(input.StartTime is not null && input.EndTime is not null, x => x.CreationTime >= input.StartTime && x.CreationTime <= input.EndTime)
                          .ToPageListAsync(input.SkipCount, input.MaxResultCount, total);
            return new PagedResultDto<QuestionGetListOutputDto>(total, await MapToGetListOutputDtosAsync(entities));
        }
    }
}
