using Acme.BookStore.Domain.Entities;
using Acme.BookStore.Domain.Shared.Enums;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Yi.Framework.SqlSugarCore.Abstractions;

namespace Acme.BookStore.SqlSugarCore.DataSeeds
{
    public class QuestionStoreDataSeed : IDataSeedContributor, ITransientDependency
    {
        private ISqlSugarRepository<QuestionAggregateRoot> _questionRepository;
        private IGuidGenerator _guidGenerator;
        public QuestionStoreDataSeed(ISqlSugarRepository<QuestionAggregateRoot> repository, IGuidGenerator guidGenerator)
        {
            _questionRepository = repository;
            _guidGenerator = guidGenerator;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (!await _questionRepository.IsAnyAsync(x => true))
            {
                await _questionRepository.InsertAsync(
                    new QuestionAggregateRoot
                    {
                        Name = "1984",
                        Type = QuestionTypeEnum.Dystopia,
                        PublishDate = new DateTime(1949, 6, 8),
                        Price = 19.84f
                    },
                    autoSave: true
                );

                await _questionRepository.InsertAsync(
                    new QuestionAggregateRoot
                    {
                        Name = "The Hitchhiker's Guide to the Galaxy",
                        Type = QuestionTypeEnum.ScienceFiction,
                        PublishDate = new DateTime(1995, 9, 27),
                        Price = 42.0f
                    },
                    autoSave: true
                );
            }
        }


    }
}
