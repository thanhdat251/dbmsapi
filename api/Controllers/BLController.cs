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
    public class BLController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        //private readonly IWebHostEnvironment _env;
        public BLController(IConfiguration configuration/*, IWebHostEnvironment env*/)
        {
            _configuration = configuration;
            //_env = env;
        }

        [HttpPost]
        public JsonResult Post(BinhLuan insert)
        {



            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DataConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("Sp_InsertBL", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@MaSP", insert.MaSp);
                    myCommand.Parameters.AddWithValue("@MaKhachHang", insert.MaKhachHang);
                    myCommand.Parameters.AddWithValue("@NoiDungBinhLuan", insert.NoiDungBinhLuan);
                    



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
                using (SqlCommand myCommand = new SqlCommand("SP_DeleteBL", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@MaBL", id);

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
