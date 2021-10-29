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
    public class HuyDHController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        //private readonly IWebHostEnvironment _env;
        public HuyDHController(IConfiguration configuration/*, IWebHostEnvironment env*/)
        {
            _configuration = configuration;
            //_env = env;
        }
        [HttpPut("{id}")]
        public JsonResult Put(int id)
        {


            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DataConn");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("SP_CusConfir4", myCon))
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
