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
        public static string ConnectionString;
        public static void Set(IConfiguration configuration)
        {
            ConnectionString = configuration["ConnectionString"];
            AppId = configuration["AppId"];
        }
    }
}
