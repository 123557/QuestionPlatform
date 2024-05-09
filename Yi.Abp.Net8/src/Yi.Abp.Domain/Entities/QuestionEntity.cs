using SqlSugar;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Yi.Framework.Core.Data;

namespace Yi.Abp.Domain.Entities
{
    /// <summary>
    /// 实体
    /// </summary>
    [SugarTable("Question")]
    public class QuestionEntity : Entity<Guid>,ISoftDelete
    {
        [SugarColumn(IsPrimaryKey = true)]
        public override Guid Id { get; protected set; }
        public bool IsDeleted { get; set; }
        public string project { get; set; }
        public string status { get; set; }
        public string category { get; set; }
        public string impact { get; set; }
        public string priority { get; set; }
        public string title { get; set; }
        [SugarColumn(ColumnDataType = "text")]
        public string? description { get; set; }
        public string? solve_user { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime? LastModificationTime { get; set; }
        public Guid? LastModifierId { get; set; }
        public Guid? CreatorId { get; set; }
        public string? Create_name { get; set; }
    }
}
