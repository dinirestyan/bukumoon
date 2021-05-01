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
    public class UserManagementController : Controller
    {
        public async Task<IActionResult> Index()
        {
            BukuViewModel bukuViewModel = new BukuViewModel();
            await SearchUser(bukuViewModel);
            return View(bukuViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SearchUser(BukuViewModel bukuViewModel)
        {
            UserModel search = new UserModel();
            search.Nama = bukuViewModel.Keyword;

            WebService ws = new WebService();
            string result = await ws.PostLilu(AppSettings.BaseUrlApi + "/UserManagement/SearchUser", JsonSerializer.Serialize(search));
            List<UserModel> listUserModel = JsonSerializer.Deserialize<List<UserModel>>(result);
            bukuViewModel.ListUser = listUserModel;
            return View("Index", bukuViewModel);
        }

        public async Task<ActionResult> InsertData(BukuViewModel bukuViewModel)
        {
            WebService ws = new WebService();

            TempData["message"] = await ws.PostLilu(AppSettings.BaseUrlApi + "/UserManagement/InsertData", JsonSerializer.Serialize(bukuViewModel));
            TempData["message"] = JsonSerializer.Deserialize<string>((string)TempData["message"]);

            return View("Index", bukuViewModel);

        }
    }
}
