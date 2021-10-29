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
    public class HDController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        //private readonly IWebHostEnvironment _env;
        public HDController(IConfiguration configuration/*, IWebHostEnvironment env*/)
        {
            _configuration = configuration;
            //_env = env;
        }
        [HttpPost]
        public JsonResult Post(HoaDon hoaDon)
        {



            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DataConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("Sp_InsertHD", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@MaKhachHang", hoaDon.MaKhachHang);
                    myCommand.Parameters.AddWithValue("@TongTien", hoaDon.TongTien);
                    


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
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
                using (SqlCommand myCommand = new SqlCommand("SP_DeleteHD", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@MaHoaDon", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }

        //khachnhanhang

        [HttpPut("{id}")]
        public JsonResult PutNhanHang( int id)
        {


            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DataConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("SP_CusConfir3", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@MaHoaDon", id);
                    
                    

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

       

        
    }
}
