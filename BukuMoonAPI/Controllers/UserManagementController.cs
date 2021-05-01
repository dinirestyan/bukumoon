using System;
using System.Linq;
using BukuMoonUI.UI.Helper;
using Microsoft.AspNetCore.Mvc;
using Obonator.Library;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using BukuMoonAPI.API.Models;

namespace BukuMoonAPI.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserManagementController : ControllerBase
    {
        public IActionResult SearchUser([FromBody] UserOptionModel userOptionModel)
        {
            string connectionString = ObonCryptography.AES.Decrypt(AppSettings.AppId, AppSettings.ConnectionString);

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    string sQuery = @"SELECT id as IdUser, nama as Nama, alamat as Alamat, no_hp as NoHp FROM pengguna WHERE lower(nama) 
                                        LIKE lower( '%" + userOptionModel.Nama + "%' ) order by nama asc";
                    conn.Open();
                    var result = conn.Query<UserOptionModel>(sQuery);
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                _ = ex.ToString();

                return Ok(null);
            }
        }

        public IActionResult InsertData([FromBody] UserOptionModel userOptionModel)
        {
            string connectionString = ObonCryptography.AES.Decrypt(AppSettings.AppId, AppSettings.ConnectionString);
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    string sQuery = @"insert into pengguna (nama, alamat, no_hp) values ( '" + userOptionModel.Nama + "', '" + userOptionModel.Alamat + "', '" + userOptionModel.NoHp + "')";
                    conn.Open();
                    var result = conn.Query<UserOptionModel>(sQuery);
                    return Ok("Berhasil Tambah User!");
                }
            }
            catch (Exception ex)
            {
                _ = ex.ToString();

                return Ok(null);
            }
        }
    }
}
