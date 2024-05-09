using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Yi.Abp.Application.Contracts.Dtos.FileManager
{
    public class FileGetListOutputDto : EntityDto<Guid>
    {
        public string FilePath { get; set; }
    }
}
