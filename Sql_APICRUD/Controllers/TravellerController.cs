using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Sql_APICRUD.Models;


namespace Sql_APICRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravellerController : ControllerBase
    {
        private readonly IConfiguration _configuration;
    public TravellerController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public JsonResult Get()
    {
        string query = @"
                              select TravellerId,TravellerName,Department
                              from dbo.Traveller ";

        DataTable table = new DataTable();
        string sqlDataSource = _configuration.GetConnectionString("TravellerAppCon");
        SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        {
            myCon.Open();
            using (SqlCommand myCommand = new SqlCommand(query, myCon))
            {
                myReader = myCommand.ExecuteReader();
                table.Load(myReader);
                myReader.Close();
                myCon.Close();

            }
        }
        return new JsonResult(table);

    }

    [HttpPost]
    public JsonResult Post(Traveller trav)
    {
        string query = @"
                              Insert into dbo.Traveller (TravellerName,Department)
                              values(@TravellerName,@Department) ";

        DataTable table = new DataTable();
        string sqlDataSource = _configuration.GetConnectionString("TravellerAppCon");
        SqlDataReader myReader;
        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        {
            myCon.Open();
            using (SqlCommand myCommand = new SqlCommand(query, myCon))
            {
                myCommand.Parameters.AddWithValue("@TravellerName", trav.TravellerName);
                myCommand.Parameters.AddWithValue("@Department", trav.Department);
                myReader = myCommand.ExecuteReader();
                table.Load(myReader);
                myReader.Close();
                myCon.Close();

            }
        }
        return new JsonResult("Added Successfully");

    }

    [HttpPut]
    public JsonResult Put(Traveller trav)
    {
        string query = @"
                              Update dbo.Traveller set TravellerName=@TravellerName, Department=@Department
                              where TravellerId=@TravellerId";

        DataTable table = new DataTable();
        string sqlDataSource = _configuration.GetConnectionString("TravellerAppCon");
        SqlDataReader myReader;
        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        {
            myCon.Open();
            using (SqlCommand myCommand = new SqlCommand(query, myCon))
            {
                myCommand.Parameters.AddWithValue("@TravellerId", trav.TravellerId);
                myCommand.Parameters.AddWithValue("@TravellerName", trav.TravellerName);
                myCommand.Parameters.AddWithValue("@Department", trav.Department);
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
        string query = @"
                              Delete from dbo.Traveller
                              where TravellerId=@TravellerId";

        DataTable table = new DataTable();
        string sqlDataSource = _configuration.GetConnectionString("TravellerAppCon");
        SqlDataReader myReader;
        using (SqlConnection myCon = new SqlConnection(sqlDataSource))
        {
            myCon.Open();
            using (SqlCommand myCommand = new SqlCommand(query, myCon))
            {
                myCommand.Parameters.AddWithValue("@TravellerId ", id);
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

