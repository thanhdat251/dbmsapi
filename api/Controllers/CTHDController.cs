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
    public class CTHDController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        //private readonly IWebHostEnvironment _env;
        public CTHDController(IConfiguration configuration/*, IWebHostEnvironment env*/)
        {
            _configuration = configuration;
            //_env = env;
        }

        [HttpPost]
        public JsonResult Post(ChiTietHoaDon insert)
        {



            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DataConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("Sp_InsertCTHD", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@MaSP", insert.MaSp);
                    myCommand.Parameters.AddWithValue("@MaHoaDon", insert.MaHoaDon);
                    myCommand.Parameters.AddWithValue("@SoLuong", insert.SoLuong);
                    myCommand.Parameters.AddWithValue("@DonGia", insert.DonGia);


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }
    }
}
