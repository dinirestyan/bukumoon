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
    public class PinjamController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetOptionUser()
        {
            string connectionString = ObonCryptography.AES.Decrypt(AppSettings.AppId, AppSettings.ConnectionString);
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {

                    string sQuery = @"SELECT id as IdUser
                                  ,nama as NamaUser
                              FROM pengguna";
                    conn.Open();
                    var result = conn.Query<OptionModel>(sQuery);
                    return Ok(result);

                }
            }
            catch (Exception ex)
            {
                _ = ex.ToString();

                return Ok(null);
            }

        }

        [HttpPost]
        public IActionResult GetOptionBuku()
        {
            string connectionString = ObonCryptography.AES.Decrypt(AppSettings.AppId, AppSettings.ConnectionString);
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {

                    string sQuery = @"SELECT id as IdBuku
                                  ,judul as JudulBuku
                                  ,status_pinjam as Stock
                              FROM buku";
                    conn.Open();
                    var result = conn.Query<BukuModel>(sQuery);
                    return Ok(result);

                }
            }
            catch (Exception ex)
            {
                _ = ex.ToString();

                return Ok(null);
            }

        }
        [HttpPost]
        public IActionResult SearchBuku([FromBody] SearchBukuModel searchBukuModel)
        {
            string connectionString = ObonCryptography.AES.Decrypt(AppSettings.AppId, AppSettings.ConnectionString);

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    string sQuery = @"SELECT id as IdBuku, judul as JudulBuku, status_pinjam as Stock FROM buku WHERE lower(judul) 
                                        LIKE lower( '%" + searchBukuModel.Keyword + "%' ) order by judul asc";
                    conn.Open();
                    var result = conn.Query<BukuModel>(sQuery);
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                _ = ex.ToString();

                return Ok(null);
            }
        }

        public IActionResult GetDataById([FromBody] BukuModel model)
        {
            string connectionString = ObonCryptography.AES.Decrypt(AppSettings.AppId, AppSettings.ConnectionString);

            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    string sQuery = @"SELECT judul as JudulBuku, status as Stock FROM buku WHERE id = " + model.IdBuku;
                    conn.Open();
                    var result = conn.Query<BukuModel>(sQuery);

                    return Ok(result.FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                _ = ex.ToString();

                return Ok(null);
            }
        }

        public IActionResult InsertData([FromBody] PinjamModel model)
        {
            string connectionString = ObonCryptography.AES.Decrypt(AppSettings.AppId, AppSettings.ConnectionString);
            try
            {
                using (IDbConnection conn = new SqlConnection(connectionString))
                {
                    string sQuery = @"insert into transaksi (id_buku, id_user, tanggal_pinjam, tanggal_kembali) values ( '" + model.IdBuku + "', '" + model.IdUser + "', '" + model.TanggalPinjam +  "', '" + model.TanggalKembali + "')";
                    conn.Open();
                    var result = conn.Query<PinjamModel>(sQuery);
                    return Ok("Berhasil Pinjam Buku!");
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
