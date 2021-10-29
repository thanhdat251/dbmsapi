using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SPController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        //private readonly IWebHostEnvironment _env;
        public SPController(IConfiguration configuration/*, IWebHostEnvironment env*/)
        {
            _configuration = configuration;
            //_env = env;
        }

        [HttpPost]
        public JsonResult Post(SanPham sanPham)
        {



            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DataConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("Sp_InsertSP", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@MaDanhMuc", sanPham.MaDanhMuc);
                    myCommand.Parameters.AddWithValue("@TenSP", sanPham.TenSp);
                    myCommand.Parameters.AddWithValue("@HinhAnh", sanPham.HinhAnh);
                    myCommand.Parameters.AddWithValue("@MoTa", sanPham.MoTa);
                    myCommand.Parameters.AddWithValue("@DonGia", sanPham.DonGia);
                    myCommand.Parameters.AddWithValue("@SoLuongCon", sanPham.SoLuongCon);
                    myCommand.Parameters.AddWithValue("@Anh1", sanPham.Anh1);
                    myCommand.Parameters.AddWithValue("@Anh2", sanPham.Anh2);
                    myCommand.Parameters.AddWithValue("@Anh3", sanPham.Anh3);
                    

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }
        [HttpPut]
        public JsonResult Put(SanPham sanPham)
        {


            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DataConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("SP_UpDateSP", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@MaSP", sanPham.MaSp);
                    myCommand.Parameters.AddWithValue("@MaDanhMuc", sanPham.MaDanhMuc);
                    myCommand.Parameters.AddWithValue("@TenSP", sanPham.TenSp);
                    myCommand.Parameters.AddWithValue("@HinhAnh", sanPham.HinhAnh);
                    myCommand.Parameters.AddWithValue("@MoTa", sanPham.MoTa);
                    myCommand.Parameters.AddWithValue("@DonGia", sanPham.DonGia);
                    myCommand.Parameters.AddWithValue("@SoLuongCon", sanPham.SoLuongCon);
                    myCommand.Parameters.AddWithValue("@Anh1", sanPham.Anh1);
                    myCommand.Parameters.AddWithValue("@Anh2", sanPham.Anh2);
                    myCommand.Parameters.AddWithValue("@Anh3", sanPham.Anh3);

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
                using (SqlCommand myCommand = new SqlCommand("SP_DeleteSP", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@MaSP", id);

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
