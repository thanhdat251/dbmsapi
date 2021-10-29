using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using api.Models;
using System.Data;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KHController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        //private readonly IWebHostEnvironment _env;
        public KHController(IConfiguration configuration/*, IWebHostEnvironment env*/)
        {
            _configuration = configuration;
            //_env = env;
        }

        [HttpPost]
        public JsonResult Post(KhachHang insert)
        {



            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DataConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("Sp_InsertKH", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@Ten", insert.Ten);
                    myCommand.Parameters.AddWithValue("@TenDangNhap", insert.TenDangNhap);
                    myCommand.Parameters.AddWithValue("@MatKhau", insert.MatKhau);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(KhachHang khachHang)
        {
            

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DataConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("SP_UpDateKH", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@MaKhachHang", khachHang.MaKhachHang);
                    myCommand.Parameters.AddWithValue("@TenDangNhap", khachHang.TenDangNhap);
                    myCommand.Parameters.AddWithValue("@MatKhau", khachHang.MatKhau);
                    myCommand.Parameters.AddWithValue("@AnhDaiDien", khachHang.AnhDaiDien);
                    myCommand.Parameters.AddWithValue("@Email", khachHang.Email);
                    myCommand.Parameters.AddWithValue("@Ten", khachHang.Ten);
                    myCommand.Parameters.AddWithValue("@DiaChi", khachHang.DiaChi);
                    myCommand.Parameters.AddWithValue("@SDT", khachHang.Sdt);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }


        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DataConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("SP_DeleteKH", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@MaKhachHang", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }
    }
}
