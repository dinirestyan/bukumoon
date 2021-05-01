using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BukuMoonUI.UI.Helper
{
    public class AppSettings
    {
        public static string AppId;
        public static int Port;
        public static string BaseUrlApi;
        public static void Set(IConfiguration configuration)
        {
            AppId = configuration["AppSettings:AppId"];
            Port = int.Parse(configuration["AppSettings:Port"]);
            BaseUrlApi = configuration["AppSettings:BaseUrlApi"];
        }
    }
}
