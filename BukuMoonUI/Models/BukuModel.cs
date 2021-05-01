using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BukuMoonUI.UI.Models
{
    public class BukuModel
    {
        public string IdBuku { get; set; }
        public string JudulBuku { get; set; }
        public string Stock { get; set; }
    }
}
