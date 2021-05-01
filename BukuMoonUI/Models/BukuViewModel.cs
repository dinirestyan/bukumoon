using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BukuMoonUI.UI.Models
{
    public class BukuViewModel
    {
        public BukuViewModel()
        {
            ListOptionUser = new List<SelectListItem>();
            ListOptionBuku = new List<SelectListItem>();
            ListBuku = new List<BukuModel>();
            ListUser = new List<UserModel>();
        }

        public List<BukuModel> ListBuku { get; set; }
        public List<UserModel> ListUser { get; set; }

        public string Keyword { get; set; }
        public string Id { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string NoHp { get; set; }
        public string Judul { get; set; }
        public string User { get; set; }
        public string TglPinjam { get; set; }
        public string TglKembali { get; set; }
        public List<SelectListItem> ListOptionUser { get; set; }
        public List<SelectListItem> ListOptionBuku { get; set; }
    }
}
