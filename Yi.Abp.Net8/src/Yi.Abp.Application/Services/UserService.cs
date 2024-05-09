using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Users;
using Yi.Framework.Rbac.Domain.Entities;
using Yi.Framework.Rbac.Domain.Extensions;

namespace Yi.Abp.Application.Services
{
    public class UserService:ApplicationService
    {

        public string GetCurrentUser()
        {
            //当token鉴权之后，可以直接获取
            if (CurrentUser.Id is not null)
            {
                //权限
                CurrentUser.GetPermissions();

                //角色信息
                CurrentUser.GetRoleInfo();

                //部门id
                CurrentUser.GetDeptId();
                CurrentUser.GetAllClaims();
                //return CurrentUser.UserName;
                return CurrentUser.Name;
            }
            return "";
        }
    }
}
