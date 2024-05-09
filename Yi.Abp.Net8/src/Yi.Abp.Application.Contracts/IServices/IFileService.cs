using Microsoft.AspNetCore.Http;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
using Yi.Abp.Application.Contracts.Dtos.FileManager;

namespace Yi.Abp.Application.Contracts.IServices
{
    public interface IFileService : IApplicationService
    {
        Task<string> GetFileReturnPathAsync(Guid code, bool? isThumbnail);
        //Task<List<FileGetListOutputDto>> Post(IFormFileCollection file);
        Task<List<FileGetListOutputDto>> Post(IFormFileCollection file,Guid? questionid);
        Task<List<FileGetListOutputDto>> getList(Guid questionid);

    }
}
