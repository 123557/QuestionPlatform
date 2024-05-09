using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Settings;

namespace Yi.Abp.Application.Services
{
    public class EmailSettingProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            context.Add(
                new SettingDefinition("Smtp.Host", "smtp.qq.com"),
                new SettingDefinition("Smtp.Port", "587"),
                new SettingDefinition("Smtp.UserName","1179949027@qq.com"),
                new SettingDefinition("Smtp.Password", "ortkaokdewyaghee", isEncrypted: true),
                new SettingDefinition("Smtp.EnableSsl", "false"),
                new SettingDefinition("Smtp.Domain", "smtp.qq.com"),
                new SettingDefinition("Smtp.UseDefaultCredentials", "false"),
                new SettingDefinition("DefaultFromAddress", "1179949027@qq.com"),
                new SettingDefinition("DefaultFromDisplayName", "1179949027@qq.com")
            );
        }
    }
}
