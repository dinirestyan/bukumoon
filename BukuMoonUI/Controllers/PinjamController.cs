using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BukuMoonUI.UI.Helper;
using BukuMoonUI.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace BukuMoonUI.UI.Controllers
{
    public class PinjamController : Controller
    {
        public async Task<IActionResult> Index()
        {
            BukuViewModel bukuViewModel = new BukuViewModel();
            await Load(bukuViewModel);
            return View(bukuViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SearchBuku(BukuViewModel bukuViewModel)
        {
            SearchBukuModel search = new SearchBukuModel();
            search.Keyword = bukuViewModel.Keyword;

            WebService ws = new WebService();
            string result = await ws.PostLilu(AppSettings.BaseUrlApi + "/Pinjam/SearchBuku", JsonSerializer.Serialize(search));
            List<BukuModel> listBukuModel = JsonSerializer.Deserialize<List<BukuModel>>(result);
            bukuViewModel.ListBuku = listBukuModel;
            await Load(bukuViewModel);
            return View("Index", bukuViewModel);
        }

        private async Task Load(BukuViewModel bukuViewModel)
        {
            bukuViewModel.ListOptionUser.Add(new SelectListItem { Text = "Pilih User", Value = "0", Selected = true });
            bukuViewModel.ListOptionBuku.Add(new SelectListItem { Text = "Pilih Buku", Value = "0", Selected = true });

            WebService ws = new WebService();
            string resultOptUser = await ws.PostLilu(AppSettings.BaseUrlApi + "/Pinjam/GetOptionUser", "");
            List<CommonOptionModel> userOptionModel = JsonSerializer.Deserialize<List<CommonOptionModel>>(resultOptUser);

            for (int i = 0; i < userOptionModel.Count; i++)
            {
                bukuViewModel.ListOptionUser.Add(new SelectListItem { Text = userOptionModel[i].NamaUser, Value = userOptionModel[i].IdUser });
            }

            WebService ws2 = new WebService();
            string resultOptBuku = await ws2.PostLilu(AppSettings.BaseUrlApi + "/Pinjam/GetOptionBuku", "");
            List<CommonOptionModel> bukuOptionModel = JsonSerializer.Deserialize<List<CommonOptionModel>>(resultOptBuku);

            for (int i = 0; i < bukuOptionModel.Count; i++)
            {
                if (bukuOptionModel[i].Stock.Equals("Tidak Tersedia"))
                {
                 //do nothing
                }
                else
                {
                    bukuViewModel.ListOptionBuku.Add(new SelectListItem { Text = bukuOptionModel[i].JudulBuku, Value = bukuOptionModel[i].IdBuku });
                }
                
            }
        }

        public async Task<ActionResult> InsertData(BukuViewModel bukuViewModel)
        {
            PinjamModel model = new PinjamModel();
            model.IdBuku = bukuViewModel.Judul;
            model.IdUser = bukuViewModel.User;
            model.TanggalPinjam = bukuViewModel.TglPinjam;
            model.TanggalKembali = bukuViewModel.TglKembali;

            WebService ws = new WebService();

            TempData["message"] = await ws.PostLilu(AppSettings.BaseUrlApi + "/Pinjam/InsertData", JsonSerializer.Serialize(model));
            TempData["message"] = JsonSerializer.Deserialize<string>((string)TempData["message"]);
            await Load(bukuViewModel);

            return View("Index", bukuViewModel);

        }
    }
}
