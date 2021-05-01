using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BukuMoonAPI.API.Models
{
    public class PinjamModel
    {
        public string IdBuku { get; set; }
        public string IdUser { get; set; }
        public string TanggalPinjam { get; set; }
        public string TanggalKembali { get; set; }
    }
}
