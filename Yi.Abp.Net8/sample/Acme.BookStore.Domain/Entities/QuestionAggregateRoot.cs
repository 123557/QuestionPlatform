﻿using Acme.BookStore.Domain.Shared.Enums;
using SqlSugar;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Domain.Entities
{
    [SugarTable("Question")]
    public class QuestionAggregateRoot : AuditedAggregateRoot<Guid>
    {
        [SugarColumn(IsPrimaryKey = true)]
        public override Guid Id { get; protected set; }
        public string Name { get; set; }

        public QuestionTypeEnum Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }

        [SugarColumn(IsIgnore = true)]
        public override ExtraPropertyDictionary ExtraProperties { get; protected set; }
    }
}
