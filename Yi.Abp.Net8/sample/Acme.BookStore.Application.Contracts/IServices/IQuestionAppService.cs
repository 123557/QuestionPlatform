using Acme.BookStore.Application.Contracts.Dtos.Book;
using Volo.Abp.Application.Dtos;
using Yi.Framework.Ddd.Application.Contracts;

namespace Acme.BookStore.Application.Contracts.IServices
{
    public interface IQuestionAppService :
      IYiCrudAppService< //Defines CRUD methods
          QuestionDto, //Used to show books
          Guid, //Primary key of the book entity
          PagedAndSortedResultRequestDto, //Used for paging/sorting
          QuestionCreateUpdateDto> //Used to create/update a book
    {

    }
}
