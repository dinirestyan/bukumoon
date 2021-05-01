using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BukuMoonUI.UI.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            ListOptionUser = new List<SelectListItem>();
            ListBuku = new List<BukuModel>();
        }
        public List<BukuModel> ListBuku { get; set; }
        public List<SelectListItem> ListOptionUser { get; set; }

    }
}
